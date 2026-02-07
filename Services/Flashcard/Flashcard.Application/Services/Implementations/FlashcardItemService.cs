using AutoMapper;
using Flashcard.Application.DTOs;
using Flashcard.Application.Interfaces;
using Flashcard.Domain.Entities;
using Flashcard.Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Flashcard.Application.Services;

public class FlashcardItemService : IFlashcardItemService
{
    private readonly IFlashcardRepository _repository;
    private readonly IMapper _mapper;
    private readonly IDistributedCache _cache;
    private const string CacheKey = "all_flashcards";

    public FlashcardItemService(IFlashcardRepository repository, IMapper mapper, IDistributedCache cache)
    {
        _repository = repository;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<IEnumerable<FlashcardItemResponse>> GetAllAsync()
    {
        var cachedData = await _cache.GetStringAsync(CacheKey);

        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonSerializer.Deserialize<IEnumerable<FlashcardItemResponse>>(cachedData)!;
        }

        var entities = await _repository.GetAllAsync();
        var response = _mapper.Map<IEnumerable<FlashcardItemResponse>>(entities);

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

        await _cache.SetStringAsync(CacheKey, JsonSerializer.Serialize(response), options);

        return response;
    }

    public async Task<FlashcardItemResponse> CreateAsync(FlashcardItemRequest request)
    {
        var entity = _mapper.Map<FlashcardItem>(request);
        entity.Id = Guid.NewGuid();

        await _repository.AddAsync(entity);
        await _cache.RemoveAsync(CacheKey);

        return _mapper.Map<FlashcardItemResponse>(entity);
    }

    public async Task<IEnumerable<FlashcardItemResponse>> CreateRangeAsync(IEnumerable<FlashcardItemRequest> requests)
    {
        var entities = _mapper.Map<IEnumerable<FlashcardItem>>(requests).ToList();

        foreach (var entity in entities)
        {
            entity.Id = Guid.NewGuid();
        }

        await _repository.AddRangeAsync(entities);

        await _cache.RemoveAsync(CacheKey);

        return _mapper.Map<IEnumerable<FlashcardItemResponse>>(entities);
    }
    public async Task<IEnumerable<FlashcardItemResponse>> GetByGroupIdAsync(Guid groupId)
    {
        string groupCacheKey = $"flashcards_group_{groupId}";
        var cachedData = await _cache.GetStringAsync(groupCacheKey);

        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonSerializer.Deserialize<IEnumerable<FlashcardItemResponse>>(cachedData)!;
        }

        var entities = await _repository.GetByGroupIdAsync(groupId);
        var response = _mapper.Map<IEnumerable<FlashcardItemResponse>>(entities);

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

        // Cache lại kết quả theo GroupId
        await _cache.SetStringAsync(groupCacheKey, JsonSerializer.Serialize(response), options);

        return response;
    }
}