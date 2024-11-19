using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moneto.API.Controllers.Base;
using Moneto.Application.AuthBusiness.Requests.Queries;
using OperationResult;

namespace Moneto.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : AppBaseController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] SignInQuery query) => await SendRequestAsync(query);
}