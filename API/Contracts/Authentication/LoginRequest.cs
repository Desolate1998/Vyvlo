namespace Contracts.Authentication;

public record LoginRequest(

    /// <summary>
    /// User email address
    /// </summary>
    string Email,

    /// <summary>
    /// User password
    /// </summary>
    string Password
);
