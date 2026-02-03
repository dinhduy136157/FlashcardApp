using AutoMapper;
using Flashcard.Application.DTOs;
using Flashcard.Domain.Entities;

namespace Flashcard.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<FlashcardItem, FlashcardItemResponse>().ReverseMap();
        CreateMap<FlashcardItemRequest, FlashcardItem>().ReverseMap();
    }
}   