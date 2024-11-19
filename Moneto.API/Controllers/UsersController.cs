using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moneto.API.Controllers.Base;
using Moneto.Application.UsersBusiness.Requests.Commands;

namespace Moneto.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : AppBaseController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command) => await SendRequestAsync(command);

   
}
