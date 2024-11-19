using MediatR;
using Moneto.Shared.Users;
using OperationResult;

namespace Moneto.Application.UsersBusiness.Requests.Commands;

public class CreateUserCommand : IRequest<Result<CreateUserCommandViewModel>> {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}