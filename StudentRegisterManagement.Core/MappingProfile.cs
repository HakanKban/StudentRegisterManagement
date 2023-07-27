using AutoMapper;
using StudentRegisterManagement.Core.Dtos;
using StudentRegisterManagement.Core.Entities;

namespace StudentRegisterManagement.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentCreateDTO, Student>().ReverseMap();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
            CreateMap<StudentDTO, Student>().ReverseMap();
            CreateMap<LessonCreateDTO, Lesson>().ReverseMap();
            CreateMap<LessonDTO, Lesson>().ReverseMap();
            CreateMap<LessonUpdateDTO, Lesson>().ReverseMap();
            CreateMap<NotesCreateDTO, Notes > ().ReverseMap();
            CreateMap<NotesUpdateDTO, Notes > ().ReverseMap();
            CreateMap<NotesDTO, Notes > ().ReverseMap();
        }
    }
}
