using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialRank.Areas.Identity.Data;
using SocialRank.Data;

namespace SocialRank.Controllers;

public class SearchController : Controller
{
    private readonly SocialRankContext _context;
    private readonly UserManager<SocialRankUser> _userManager;

    public SearchController(SocialRankContext context, UserManager<SocialRankUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    /*
    public async Task<List<SocialRankUser>> UserSearchAsync(string searchText)
    {
        var users = await _userManager.Users
            .Where(u =>
                !string.IsNullOrWhiteSpace(searchText) &&
                (u.UserName != null && u.UserName.Contains(searchText)) ||
                (u.Email != null && u.Email.Contains(searchText)) ||
                (u.PhoneNumber != null && u.PhoneNumber.Contains(searchText)) ||
                (u.FirstName != null && u.FirstName.Contains(searchText)) ||
                (u.LastName != null && u.LastName.Contains(searchText)) ||
                (u.MilitaryRank != null && u.MilitaryRank.Name != null && u.MilitaryRank.Name.Contains(searchText)) ||
                (u.Clearance != null && u.Clearance.Name != null && u.Clearance.Name.Contains(searchText))
            ).ToListAsync();
        return users;
    }*/
}