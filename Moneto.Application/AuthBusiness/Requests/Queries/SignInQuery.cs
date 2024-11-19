using MediatR;
using OperationResult;

namespace Moneto.Application.AuthBusiness.Requests.Queries;

public class SignInQuery : IRequest<Result>
{
    public string Email { get; set; }
    public string Password { get; set; }
}