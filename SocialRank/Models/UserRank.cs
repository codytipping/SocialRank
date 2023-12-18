namespace SocialRank.Models;

public class UserRank
{
    public string? UserId { get; set; } = string.Empty;
    public double Rank { get; set; } = 0.0;
    public List<UserRank>? Links { get; } = new List<UserRank>();
}