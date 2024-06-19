namespace BuberDinner.Contratcs.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);