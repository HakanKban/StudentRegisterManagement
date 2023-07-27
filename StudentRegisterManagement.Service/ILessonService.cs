using StudentRegisterManagement.Core;
using StudentRegisterManagement.Core.Dtos;

namespace StudentRegisterManagement.Service
{
    public interface ILessonService 
    {
        Task<CustomResponse<NoContent>> CreateLessonAsync(LessonCreateDTO lessonCreateDTO);    
        Task<CustomResponse<NoContent>> UpdateLessonAsync(LessonUpdateDTO lessonCreateDTO);    
        Task<CustomResponse<NoContent>> DeleteLessonAsync(Guid Id);    
    }
}
