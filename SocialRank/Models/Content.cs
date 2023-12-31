﻿using SocialRank.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialRank.Models;

public class Content
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rank { get; set; } = 1.0;

    [ForeignKey("User")]
    public string? UserId { get; set; } = string.Empty;
    public virtual SocialRankUser? User { get; set; }

    public List<UserContent>? Links { get; set; } = new List<UserContent>();
}

public class UserContent
{
    [ForeignKey("Content")]
    public string? ContentId { get; set; } = string.Empty;
    public virtual Content? Content { get; set; }

    [ForeignKey("User")]
    public string? UserId { get; set; } = string.Empty;
    public virtual SocialRankUser? User { get; set; }
}