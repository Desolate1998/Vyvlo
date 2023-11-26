namespace Contracts.Authentication;

public record RegisterRequest (
    /// <summary>
    /// The email address the user would Like to use
    /// </summary>
    string Email,

    /// <summary>
    /// The password the user would like to use
    /// </summary>
    string Password,

    /// <summary>
    /// The password the user would like to use
    /// </summary>
    string FirstName,

    /// <summary>
    /// The password the user would like to use
    /// </summary>
    string LastName
);
