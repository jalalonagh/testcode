using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFramework.Filters;

namespace WebFramework.Api
{
    [ApiController]
    [ApiResultFilter]
    [Route("api/v{version:apiVersion}/[controller]")]// api/v1/[controller]
    [Authorize("Authorization")]
    public class BaseController : Controller
    {
        protected bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
        protected string Username => HttpContext.User?.Identity?.Name;
    }
}