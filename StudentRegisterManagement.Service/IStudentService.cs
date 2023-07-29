using StudentRegisterManagement.Core;
using StudentRegisterManagement.Core.Dtos;

namespace StudentRegisterManagement.Service;
public interface IStudentService
{
    Task<CustomResponse<NoContent>> CreateStudentAsync(StudentCreateDTO studentCreateDTO);
    Task<CustomResponse<NoContent>> UpdateStudentAsync(StudentUpdateDTO studentUpdate);
    Task<CustomResponse<NoContent>> DeleteStudentAsync(Guid Id);
    Task<CustomResponse<List<StudentDTO>>> GetAllStudent();
}
