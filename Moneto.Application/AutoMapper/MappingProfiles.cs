using AutoMapper;
using Moneto.Domain.Entities;
using Moneto.Shared.Expenses;

namespace Moneto.Application.AutoMapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Expense, ExpenseViewModel>();
    }
}