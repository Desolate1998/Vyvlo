namespace Contracts.Authentication;

public class RegisterRequest
{
    /// <summary>
    /// The email address the user would Like to use
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The password the user would like to use
    /// </summary>
    public string Password { get; set; } 

    /// <summary>
    /// The password the user would like to use
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The password the user would like to use
    /// </summary>
    public string LastName { get; set; }
}
