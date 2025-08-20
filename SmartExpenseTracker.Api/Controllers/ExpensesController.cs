using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.Domain.Interfaces;
using SmartExpenseTracker.Shared.Dto;

namespace SmartExpenseTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ExpenseDto>> GetAll()
    {
        var expenses = _expenseService.GetAll()
            .Select(e => new ExpenseDto
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Category = e.Category,
                Date = e.Date
            })
            .ToList();

        return Ok(expenses);
    }

    [HttpGet("{id}")]
    public ActionResult<ExpenseDto> GetById(int id)
    {
        var expense = _expenseService.GetById(id);

        if (expense == null) return NotFound();

        var dto = new ExpenseDto
        {
            Id = expense.Id,
            Description = expense.Description,
            Amount = expense.Amount,
            Category = expense.Category,
            Date = expense.Date
        };

        return Ok(dto);
    }
}