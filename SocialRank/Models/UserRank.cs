namespace SocialRank.Models;

public class UserRank
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public double Rank { get; set; } = 1.0;
    public List<UserRank>? Links { get; } = new List<UserRank>();
}