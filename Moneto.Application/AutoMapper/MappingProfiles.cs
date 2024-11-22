using AutoMapper;
using Moneto.Application.ExpenseCategoriesBusiness.Requests.Commands;
using Moneto.Application.ExpensesBusiness.Requests.Commands;
using Moneto.Domain.Entities;
using Moneto.Shared.ExpenseCategories;
using Moneto.Shared.Expenses;

namespace Moneto.Application.AutoMapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Expense, ExpenseViewModel>().ReverseMap();
        CreateMap<CreateExpenseCommand, Expense>().ReverseMap();
        CreateMap<CreateExpenseCategoryCommand, ExpenseCategory>().ReverseMap();
        CreateMap<ExpenseCategory, ExpenseCategoryViewModel>().ReverseMap();
    }
}