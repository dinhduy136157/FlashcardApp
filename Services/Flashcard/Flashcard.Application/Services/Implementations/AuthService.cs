using AutoMapper;
using Flashcard.Application.DTOs;
using Flashcard.Domain.Interfaces;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null) throw new Exception("Email already exists");

        var user = _mapper.Map<User>(request);
        user.Id = Guid.NewGuid();

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse?> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null || user.Password != request.Password) return null;

        return _mapper.Map<UserResponse>(user);
    }
}