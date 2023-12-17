using SocialRank.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialRank.Models;

public class Content
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rank { get; set; } = 0.0;

    [ForeignKey("User")]
    public string? UserId { get; set; } = string.Empty;
    public virtual SocialRankUser? User { get; set; }

    public List<Content>? Links { get; } = new List<Content>();
}