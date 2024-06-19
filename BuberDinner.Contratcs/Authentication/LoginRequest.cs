namespace BuberDinner.Contratcs.Authentication;

public record LoginRequest(
    string Email,
    string Password);