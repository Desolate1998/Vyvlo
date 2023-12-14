namespace Common.JwtTokenGenerator;

public interface IJwtTokenGenerator
{
    string GenerateToken(long userId, string firstName, string lastName);
}
