using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moneto.API.Controllers.Base;
using Moneto.Application.ExpenseCategoriesBusiness.Requests.Commands;
using Moneto.Application.ExpenseCategoriesBusiness.Requests.Queries;

namespace Moneto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ExpenseCategoriesController : AppBaseController
{
    public ExpenseCategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenseCategories() => await SendRequestAsync(new ListExpenseCategoriesQuery());

    [HttpPost]
    public async Task<IActionResult> CreateExpenseCategory([FromBody] CreateExpenseCategoryCommand command) => await SendRequestAsync(command);
}