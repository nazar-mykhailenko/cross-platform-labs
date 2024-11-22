using Lab6.Api;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RefCustomerTypesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RefCustomerTypesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RefCustomerType>>> GetAll()
    {
        var customerTypes = await _context.RefCustomerTypes.ToListAsync();
        return Ok(customerTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RefCustomerType>> GetById(int id)
    {
        var customerType = await _context.RefCustomerTypes.FindAsync(id);

        if (customerType == null)
        {
            return NotFound();
        }

        return Ok(customerType);
    }
}
