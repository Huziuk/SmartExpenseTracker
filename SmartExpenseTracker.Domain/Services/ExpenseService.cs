using SmartExpenseTracker.Domain.Interfaces;
using SmartExpenseTracker.Domain.Models;

namespace SmartExpenseTracker.Domain.Services;

public class ExpenseService : IExpenseService
{
    private readonly List<ExpenseEntity> _expenses =
    [
        new ()
        {
            Id = 1, Description = "Lunch", Amount = 12.5m, Category = "Food", Date = DateTime.Now.AddDays(-1)
        },
        new ()
        {
            Id = 2, Description = "Uber", Amount = 8.2m, Category = "Transport", Date = DateTime.Now.AddDays(-2)
        },
        new ()
        {
            Id = 3, Description = "Movie Ticket", Amount = 15.0m, Category = "Entertainment",
            Date = DateTime.Now.AddDays(-3)
        }
    ];

    public IEnumerable<ExpenseEntity> GetAll() => _expenses;

    public ExpenseEntity? GetById(int id) => _expenses.FirstOrDefault(e => e.Id == id);
}