using Flashcard.Application.DTOs;

namespace Flashcard.Application.Interfaces;

public interface IFlashcardItemService
{
    Task<IEnumerable<FlashcardItemResponse>> GetAllAsync();
    Task<FlashcardItemResponse> CreateAsync(FlashcardItemRequest request);
    Task<IEnumerable<FlashcardItemResponse>> CreateRangeAsync(IEnumerable<FlashcardItemRequest> requests);
}