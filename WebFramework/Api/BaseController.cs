using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebFramework.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize("Authorization")]
    public class BaseController : Controller
    {
        protected bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
        protected string Username => HttpContext.User?.Identity?.Name;
    }
}