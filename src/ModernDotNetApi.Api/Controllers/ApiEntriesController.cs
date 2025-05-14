using Microsoft.AspNetCore.Mvc;
using ModernDotNetApi.Application.DTOs;
using ModernDotNetApi.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class ApiEntriesController : ControllerBase
{
    private readonly IApiEntryService _service;

    public ApiEntriesController(IApiEntryService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApiEntryDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiEntryDto>> Get(int id)
    {
        var entry = await _service.GetByIdAsync(id);
        if (entry is null) return NotFound();
        return Ok(entry);
    }

    [HttpPost]
    public async Task<ActionResult> Post(ApiEntryDto dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.Name }, dto);
    }
}
