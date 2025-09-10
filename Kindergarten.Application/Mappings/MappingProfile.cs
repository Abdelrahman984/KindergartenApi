using AutoMapper;
using Kindergarten.Application.DTOs;
using Kindergarten.Domain.Entities;

namespace Kindergarten.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Student
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();
        CreateMap<Student, StudentReadDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.ParentFullName, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.FullName : ""))
            .ForMember(dest => dest.ParentAddress, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.Address : ""));


        // Teacher
        CreateMap<Teacher, TeacherReadDto>();
        CreateMap<TeacherCreateDto, Teacher>();
        CreateMap<TeacherUpdateDto, Teacher>();

        // Classroom
        CreateMap<Classroom, ClassroomReadDto>();
        CreateMap<ClassroomCreateDto, Classroom>();

        // Parent
        CreateMap<Parent, ParentReadDto>()
            .ForMember(dest => dest.Childrens, opt => opt.MapFrom(src => src.Childrens));
        CreateMap<ParentCreateDto, Parent>();
        CreateMap<ParentUpdateDto, Parent>();

        // Attendance
        CreateMap<Attendance, AttendanceReadDto>();
        CreateMap<AttendanceCreateDto, Attendance>();
    }

    private static int CalculateAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateOfBirth.Year;
        if (dateOfBirth.Date > today.AddYears(-age)) age--;
        return Math.Max(age, 0);
    }
}
