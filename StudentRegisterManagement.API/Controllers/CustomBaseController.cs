using Microsoft.AspNetCore.Mvc;
using StudentRegisterManagement.Core;

namespace StudentRegisterManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public ActionResult CreateActionResultInstance<T>(CustomResponse<T> response)
        {
            if (!response.Succeeded)
            {
                if (response.Args != null && response.Args.Length > 0)
                    for (var i = 0; i < response.Error.Details.Count; i++)
                        response.Error.Details[i] = string.Format(response.Error.Details[i], response.Args);
            }

            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
