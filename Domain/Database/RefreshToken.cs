namespace Domain.Database;

public class RefreshToken
{
    public long RefreshTokenID { get; set; }
    public long UserID { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public User User { get; set; }
}
