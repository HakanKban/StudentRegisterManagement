using Microsoft.AspNetCore.Mvc;
using StudentRegisterManagement.Core;
using StudentRegisterManagement.Core.Dtos;
using StudentRegisterManagement.Service;

namespace StudentRegisterManagement.API.Controllers
{
    public class HomeController : CustomBaseController
    {
        private readonly IStudentService _studentService;
        private readonly ILessonService _lessonService;

        public HomeController(IStudentService studentService, ILessonService lessonService)
        {
            _studentService = studentService;
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomResponse<NoContent>>> CreateStudent(StudentCreateDTO createDTO)
        {
            return  CreateActionResultInstance(await _studentService.CreateStudentAsync(createDTO));
        }
          
        [HttpPost]
        public async Task<ActionResult<CustomResponse<NoContent>>> CreateLesson(LessonCreateDTO createDTO)
        {
            return  CreateActionResultInstance(await _lessonService.CreateLessonAsync(createDTO));
        }

        [HttpDelete("{Id:guid}")]
        public async Task<ActionResult<CustomResponse<NoContent>>> DeleteStudent(Guid Id)
        {
            return  CreateActionResultInstance(await _studentService.DeleteStudentAsync(Id));
        }  
        [HttpDelete("{Id:guid}")]
        public async Task<ActionResult<CustomResponse<NoContent>>> DeleteLesson(Guid Id)
        {
            return  CreateActionResultInstance(await _lessonService.DeleteLessonAsync(Id));
        }

        [HttpPut]
        public async Task<ActionResult<CustomResponse<NoContent>>> UpdateStudent(StudentUpdateDTO updateDTO)
        {
            return  CreateActionResultInstance(await _studentService.UpdateStudentAsync(updateDTO));
        }

        [HttpPut]
        public async Task<ActionResult<CustomResponse<NoContent>>> UpdateLesson(LessonUpdateDTO updateDTO)
        {
            return  CreateActionResultInstance(await _lessonService.UpdateLessonAsync(updateDTO));
        }

        [HttpGet]
        public async Task<ActionResult<CustomResponse<List<StudentDTO>>>> GetAllStudent()
        {
            return  CreateActionResultInstance(await _studentService.GetAllStudent());
        }


    }
}
