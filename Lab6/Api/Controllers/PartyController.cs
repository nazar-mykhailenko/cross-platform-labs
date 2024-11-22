using Lab6.Api;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab6.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartiesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PartiesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Party>>> GetAll()
    {
        var parties = await _context.Parties.ToListAsync();
        return Ok(parties);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Party>> GetById(int id)
    {
        var party = await _context.Parties.FindAsync(id);

        if (party == null)
        {
            return NotFound();
        }

        return Ok(party);
    }
}