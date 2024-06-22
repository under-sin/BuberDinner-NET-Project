using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null)
            throw new DuplicateEmailException();

        // Create user (generate unique id)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new EmailNotFoundException();

        // 2. Validate the password is correct
        if (user.Password != password)
            throw new Exception("Invalid password.");

        // 3. Create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}