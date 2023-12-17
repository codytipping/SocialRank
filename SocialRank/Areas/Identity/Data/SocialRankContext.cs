using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialRank.Areas.Identity.Data;
using SocialRank.Models;

namespace SocialRank.Data;

public class SocialRankContext : IdentityDbContext<SocialRankUser>
{
    public SocialRankContext(DbContextOptions<SocialRankContext> options) : base(options) { }
    public DbSet<Content> Contents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<SocialRankUser>(entity => { entity.ToTable(name: "Users"); });
        builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
        builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RolesClaim"); });
        builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UsersClaim"); });
        builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UsersLogin"); });
        builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UsersRole"); });
        builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UsersToken"); });
    }
}