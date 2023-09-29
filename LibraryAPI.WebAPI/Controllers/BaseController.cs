using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator=> _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
            
    }
}
