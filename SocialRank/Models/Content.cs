namespace SocialRank.Models;

public class Content
{
    public string Name { get; set; } = string.Empty;
    public double Rank { get; set; } = 0.0;
    public List<Content> Links { get; } = new List<Content>();

    public Content(string name)
    {
        Name = name;
    }
}