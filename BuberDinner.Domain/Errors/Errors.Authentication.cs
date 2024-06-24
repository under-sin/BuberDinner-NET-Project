using ErrorOr;

namespace BuberDinner.Domain.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials
            => Error.Unauthorized(code: "Authentication.InvalidCredentials", description: "Invalid credentials");
        
        public static Error InvalidPassword
            => Error.Validation(code: "Authentication.InvalidPassword", description: "Invalid password");
    }
}