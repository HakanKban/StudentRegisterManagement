using Microsoft.AspNetCore.Mvc;
using StudentRegisterManagement.Core;
using StudentRegisterManagement.Core.Dtos;
using StudentRegisterManagement.Service;

namespace StudentRegisterManagement.API.Controllers
{
    public class HomeController : CustomBaseController
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomResponse<NoContent>>> CreateStudent(StudentCreateDTO createDTO)
        {
            return  CreateActionResultInstance(await _studentService.CreateStudentAsync(createDTO));
        }

        [HttpDelete("{Id:guid}")]
        public async Task<ActionResult<CustomResponse<NoContent>>> DeleteStudent(Guid Id)
        {
            return  CreateActionResultInstance(await _studentService.DeleteStudentAsync(Id));
        }

        [HttpPut]
        public async Task<ActionResult<CustomResponse<NoContent>>> UpdateStudent(StudentUpdateDTO updateDTO)
        {
            return  CreateActionResultInstance(await _studentService.UpdateStudentAsync(updateDTO));
        }

        [HttpGet]
        public async Task<ActionResult<CustomResponse<NoContent>>> GetAllStudent(StudentCreateDTO createDTO)
        {
            return  CreateActionResultInstance(await _studentService.CreateStudentAsync(createDTO));
        }


    }
}
