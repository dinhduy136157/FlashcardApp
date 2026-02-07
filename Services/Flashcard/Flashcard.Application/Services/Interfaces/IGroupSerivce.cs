using Flashcard.Application.DTOs;

public interface IGroupService
{
    Task<GroupResponse> CreateGroupAsync(GroupRequest request);
    Task<IEnumerable<GroupResponse>> GetUserGroupsAsync(Guid userId);
}