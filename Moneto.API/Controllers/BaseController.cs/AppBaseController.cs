using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;

namespace Moneto.API.Controllers.Base;

[ApiController]
[Route("[controller]")]
public class AppBaseController : ControllerBase
{
    private readonly IMediator _mediator;
    public AppBaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> SendRequestAsync<T>(IRequest<Result<T>> request)
    => await _mediator.Send(request) switch 
    {
        (true, var result, _) => Ok(result),
        (_, _, var error) => HandleError(error)
    };

    private IActionResult HandleError(Exception error)
    => error switch 
    {
        _ => BadRequest(error.Message)
    };
}