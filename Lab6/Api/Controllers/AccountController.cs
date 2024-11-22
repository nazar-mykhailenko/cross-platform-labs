using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab6.Api;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccountsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Account>>> Search(
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] decimal? minBalance = null,
        [FromQuery] decimal? maxBalance = null,
        [FromQuery] string? nameStart = null,
        [FromQuery] string? nameEnd = null 
    )
    {
        var query = _context
            .Accounts.Include(a => a.Customer)
            .Include(a => a.TransactionMessages)
            .Include(a => a.RefAccountType)
            .AsQueryable();

        if (startDate.HasValue)
        {
            query = query.Where(a => a.DateOpened >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(a => a.DateOpened <= endDate.Value);
        }

        if (minBalance.HasValue)
        {
            query = query.Where(a => a.CurrentBalance >= minBalance.Value);
        }

        if (maxBalance.HasValue)
        {
            query = query.Where(a => a.CurrentBalance <= maxBalance.Value);
        }

        if (!string.IsNullOrWhiteSpace(nameStart))
        {
            query = query.Where(a => a.AccountName.StartsWith(nameStart));
        }

        if (!string.IsNullOrWhiteSpace(nameEnd))
        {
            query = query.Where(a => a.AccountName.EndsWith(nameEnd));
        }

        var results = await query.ToListAsync();

        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetById(int id)
    {
        var account = await _context
            .Accounts.Include(a => a.Customer)
            .Include(a => a.RefAccountType)
            .FirstOrDefaultAsync(a => a.AccountId == id);

        if (account == null)
        {
            return NotFound();
        }

        return Ok(account);
    }
}
