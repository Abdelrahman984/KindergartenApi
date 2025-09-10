using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Application.Interfaces.Repositories;
using Kindergarten.Application.Interfaces.Services;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IClassroomRepository _classroomRepository;
    private readonly IParentRepository _parentRepository;
    private readonly IMapper _mapper;

    public AttendanceService(
        IAttendanceRepository attendanceRepository,
        IStudentRepository studentRepository,
        ITeacherRepository teacherRepository,
        IClassroomRepository classroomRepository,
        IParentRepository parentRepository,
        IMapper mapper)
    {
        _attendanceRepository = attendanceRepository;
        _studentRepository = studentRepository;
        _teacherRepository = teacherRepository;
        _classroomRepository = classroomRepository;
        _parentRepository = parentRepository;
        _mapper = mapper;
    }

    public async Task MarkAttendanceAsync(AttendanceCreateDto dto)
    {
        var existing = (await _attendanceRepository.GetByDateAsync(dto.Date))
            .FirstOrDefault(a => a.StudentId == dto.StudentId);

        if (existing is not null)
        {
            existing.UpdateStatus(dto.IsPresent);
            await _attendanceRepository.UpdateAsync(existing);
        }
        else
        {
            var attendance = _mapper.Map<Attendance>(dto);
            await _attendanceRepository.AddAsync(attendance);
        }
    }

    public async Task<IEnumerable<AttendanceReadDto>> GetStudentAttendanceAsync(Guid studentId)
    {
        var records = await _attendanceRepository.GetByStudentAsync(studentId);
        return _mapper.Map<IEnumerable<AttendanceReadDto>>(records);
    }

    public async Task<IEnumerable<AttendanceReadDto>> GetDailyAttendanceAsync(DateTime date)
    {
        var records = await _attendanceRepository.GetByDateAsync(date);
        return _mapper.Map<IEnumerable<AttendanceReadDto>>(records);
    }

    public async Task<AttendanceRateDto> GetStudentAttendanceRateAsync(Guid studentId, DateTime from, DateTime to)
    {
        if (to < from)
        {
            (from, to) = (to, from);
        }

        var records = await _attendanceRepository.GetByStudentAndRangeAsync(studentId, from, to);

        var presentDays = records.Count(r => r.IsPresent);

        var totalDays = records
            .Select(r => r.Date.Date)
            .Distinct()
            .Count();

        var rate = totalDays == 0 ? 0d : (double)presentDays / totalDays;

        return new AttendanceRateDto(studentId, from.Date, to.Date, presentDays, totalDays, rate);
    }

    public async Task<AttendanceAggregateRateDto> GetAllStudentsAttendanceRateAsync(DateTime from, DateTime to)
    {
        if (to < from) (from, to) = (to, from);

        var students = await _studentRepository.GetActiveStudentsAsync();
        var studentIds = students.Select(s => s.Id).ToArray();
        if (studentIds.Length == 0)
            return new AttendanceAggregateRateDto(from.Date, to.Date, 0, 0, 0);

        var records = await _attendanceRepository.GetByStudentsAndRangeAsync(studentIds, from, to);
        return ComputeAggregate(from, to, records);
    }

    public async Task<AttendanceAggregateRateDto> GetTeacherStudentsAttendanceRateAsync(Guid teacherId, DateTime from, DateTime to)
    {
        if (to < from) (from, to) = (to, from);

        var students = await _classroomRepository.GetStudentsByTeacherIdAsync(teacherId);
        var studentIds = students.Select(s => s.Id).ToArray();
        if (studentIds.Length == 0)
            return new AttendanceAggregateRateDto(from.Date, to.Date, 0, 0, 0);

        var records = await _attendanceRepository.GetByStudentsAndRangeAsync(studentIds, from, to);
        return ComputeAggregate(from, to, records);
    }

    public async Task<AttendanceAggregateRateDto> GetParentChildrenAttendanceRateAsync(Guid parentId, DateTime from, DateTime to)
    {
        if (to < from) (from, to) = (to, from);

        var parent = await _parentRepository.GetWithChildrenAsync(parentId);
        var studentIds = parent?.Childrens.Select(c => c.Id).ToArray() ?? Array.Empty<Guid>();
        if (studentIds.Length == 0)
            return new AttendanceAggregateRateDto(from.Date, to.Date, 0, 0, 0);

        var records = await _attendanceRepository.GetByStudentsAndRangeAsync(studentIds, from, to);
        return ComputeAggregate(from, to, records);
    }

    private static AttendanceAggregateRateDto ComputeAggregate(DateTime from, DateTime to, IEnumerable<Attendance> records)
    {
        var presentDays = records.Count(r => r.IsPresent);
        var totalDays = records
            .GroupBy(r => new { r.StudentId, Date = r.Date.Date })
            .Count();
        var rate = totalDays == 0 ? 0d : (double)presentDays / totalDays;
        return new AttendanceAggregateRateDto(from.Date, to.Date, presentDays, totalDays, rate);
    }

    public async Task<IEnumerable<AttendanceRateDto>> GetAllStudentsAttendanceRatesAsync(DateTime from, DateTime to)
    {
        if (to < from)
        {
            (from, to) = (to, from);
        }

        var records = await _attendanceRepository.GetByRangeAsync(from, to);

        var grouped = records
            .GroupBy(r => r.StudentId)
            .Select(g =>
            {
                var presentDays = g.Count(r => r.IsPresent);
                var totalDays = g.Select(r => r.Date.Date).Distinct().Count();
                var rate = totalDays == 0 ? 0d : (double)presentDays / totalDays;
                return new AttendanceRateDto(g.Key, from.Date, to.Date, presentDays, totalDays, rate);
            })
            .ToList();

        return grouped;
    }

    public async Task<double> GetStudentAttendancePercentageAsync(Guid studentId)
    {
        var records = await _attendanceRepository.GetByStudentAsync(studentId);

        if (!records.Any())
            return 0.0;

        var presentDays = records.Count(r => r.IsPresent);
        var totalDays = records.Count();

        return totalDays == 0 ? 0.0 : (double)presentDays / totalDays;
    }
}
