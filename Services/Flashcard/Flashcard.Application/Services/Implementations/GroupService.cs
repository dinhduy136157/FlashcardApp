using AutoMapper;
using Flashcard.Application.DTOs;
using Flashcard.Domain.Interfaces;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GroupService(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<GroupResponse> CreateGroupAsync(GroupRequest request)
    {
        var group = _mapper.Map<Group>(request);
        group.Id = Guid.NewGuid();

        await _groupRepository.AddAsync(group);
        await _groupRepository.SaveChangesAsync();

        return _mapper.Map<GroupResponse>(group);
    }

    public async Task<IEnumerable<GroupResponse>> GetUserGroupsAsync(Guid userId)
    {
        var groups = await _groupRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<GroupResponse>>(groups);
    }
}