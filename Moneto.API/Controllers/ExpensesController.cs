using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moneto.API.Controllers.Base;
using Moneto.Application.ExpensesBusiness.Requests.Commands;
using Moneto.Application.ExpensesBusiness.Requests.Queries;

namespace Moneto.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ExpensesController : AppBaseController
{
    public ExpensesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses() => await SendRequestAsync(new ListExpensesQuery());

    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseCommand command) => await SendRequestAsync(command);
}