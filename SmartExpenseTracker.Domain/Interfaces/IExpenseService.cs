using SmartExpenseTracker.Domain.Models;

namespace SmartExpenseTracker.Domain.Interfaces;

public interface IExpenseService
{
    IEnumerable<ExpenseEntity> GetAll();
    ExpenseEntity? GetById(int id);
}