using Flashcard.Application.DTOs;

public interface IAuthService
{
    Task<UserResponse> RegisterAsync(RegisterRequest request);
    Task<UserResponse?> LoginAsync(LoginRequest request);
}