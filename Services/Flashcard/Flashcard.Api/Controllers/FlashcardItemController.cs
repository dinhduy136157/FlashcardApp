using Microsoft.AspNetCore.Mvc;
using Flashcard.Application.DTOs;
using Flashcard.Application.Interfaces;

namespace Flashcard.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashcardItemController : ControllerBase
{
    private readonly IFlashcardItemService _service;

    public FlashcardItemController(IFlashcardItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FlashcardItemRequest request)
    {
        if (request == null) return BadRequest("Dữ liệu không hợp lệ");

        var result = await _service.CreateAsync(request);

        return Ok(result);
    }

    [HttpGet("group/{groupId:guid}")]
    public async Task<IActionResult> GetByGroupId(Guid groupId)
    {
        var result = await _service.GetByGroupIdAsync(groupId);
        return Ok(result);
    }
    
    [HttpPost("bulk")]
    public async Task<IActionResult> CreateRange([FromBody] IEnumerable<FlashcardItemRequest> requests)
    {
        var result = await _service.CreateRangeAsync(requests);
        return Ok(result);
    }
}