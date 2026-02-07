using AutoMapper;
using Flashcard.Application.DTOs;
using Flashcard.Domain.Entities;

namespace Flashcard.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Flashcard Mappings
        CreateMap<FlashcardItem, FlashcardItemResponse>().ReverseMap();
        CreateMap<FlashcardItemRequest, FlashcardItem>().ReverseMap();

        // User Mappings
        CreateMap<User, UserResponse>();
        CreateMap<RegisterRequest, User>();

        // Group Mappings
        CreateMap<Group, GroupResponse>().ReverseMap();
        CreateMap<GroupRequest, Group>().ReverseMap();
    }
}