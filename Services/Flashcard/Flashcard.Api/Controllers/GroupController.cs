using Flashcard.Application.DTOs;
using Flashcard.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flashcard.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GroupRequest request)
    {
        var result = await _groupService.CreateGroupAsync(request);
        return CreatedAtAction(nameof(GetByUserId), new { userId = request.UserId }, result);
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var result = await _groupService.GetUserGroupsAsync(userId);
        return Ok(result);
    }
}