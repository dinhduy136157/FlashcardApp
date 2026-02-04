using AutoMapper;
using Flashcard.Application.DTOs;
using Flashcard.Application.Interfaces;
using Flashcard.Domain.Entities;
using Flashcard.Domain.Interfaces;

namespace Flashcard.Application.Services;

public class FlashcardItemService : IFlashcardItemService
{
    private readonly IFlashcardRepository _repository;
    private readonly IMapper _mapper;

    public FlashcardItemService(IFlashcardRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FlashcardItemResponse>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<FlashcardItemResponse>>(entities);
    }

    public async Task<FlashcardItemResponse> CreateAsync(FlashcardItemRequest request)
    {
        var entity = _mapper.Map<FlashcardItem>(request);
        entity.Id = Guid.NewGuid();

        await _repository.AddAsync(entity);

        return _mapper.Map<FlashcardItemResponse>(entity);
    }
}