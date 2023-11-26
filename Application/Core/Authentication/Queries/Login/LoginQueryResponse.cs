namespace Application.Core.Authentication.Queries.Login
{

    public record LoginQueryResponse(
        string Token,
        string FirstName,
        string LastName,
        string Email);


}
