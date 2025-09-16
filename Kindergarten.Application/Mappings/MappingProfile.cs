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
        CreateMap<Teacher, TeacherReadDto>()
            .ForMember(dest => dest.SubjectName,
                opt => opt.MapFrom(src => src.Subject.Name));
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
        CreateMap<Attendance, AttendanceReadDto>()
           .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.FullName))
           .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Student.Classroom!.Name))
           .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(src => src.ArrivalTime));
        CreateMap<AttendanceCreateDto, Attendance>();

        // Subject
        CreateMap<Subject, SubjectReadDto>();
        CreateMap<SubjectCreateDto, Subject>();

    }
}
