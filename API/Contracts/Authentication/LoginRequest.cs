namespace Contracts.Authentication;

public class LoginRequest
{
    /// <summary>
    /// User email address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// User password
    /// </summary>
    public string Password { get; set; }
}

