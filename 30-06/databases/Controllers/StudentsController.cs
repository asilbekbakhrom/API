using Microsoft.AspNetCore.Mvc;
using databases.Data;
using Microsoft.EntityFrameworkCore;
using databases.Entities;

namespace databases.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<StudentsController> _logger;

    public StudentsController(
        ILogger<StudentsController> logger,
        AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Students.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Dtos.Student student)
    {
        var entity = new Student()
        {
            Id = Guid.NewGuid(),
            Fullname = student.Fullname,
            Birthdate = student.Birthdate,
            Phone = student.Phone,
            Email = student.Email,
            Grade = student.Grade,
            Language = student.Language switch
            {
                Dtos.ELanguage.English => ELanguage.English,
                Dtos.ELanguage.Russian => ELanguage.Russian,
                _ => ELanguage.Uzbek
            }
        };

        await _context.Students.AddAsync(entity);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Create), student);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        return Ok(await _context.Students.FirstOrDefaultAsync(s => s.Id == id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromRoute] Guid id)
    {
        var entity = await _context.Students.FindAsync(id);
        if(entity is null)
            return NotFound();
        
        _context.Students.Remove(entity);
        await _context.SaveChangesAsync();

        return Ok();
    }
}