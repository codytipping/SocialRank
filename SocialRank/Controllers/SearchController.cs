using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialRank.Algorithms;
using SocialRank.Data;
using SocialRank.Models;

namespace SocialRank.Controllers;

public class SearchController : Controller
{
    private readonly SocialRankContext _context;

    public SearchController(SocialRankContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> Search(string searchText)
    {
        var contents = await SearchContents(searchText);
        var userSearch = SearchUsers(contents);
        var users = RankCalculator.CalculateRank(userSearch);
        return View(users);
    }

    private async Task<List<Content>> SearchContents(string searchText)
    {
        var contents = await _context.Contents.Where(u =>
            !string.IsNullOrWhiteSpace(searchText) && 
            (u.Title != null && u.Title.Contains(searchText)) || 
            (u.Description != null && u.Description.Contains(searchText))
        ).ToListAsync();
        return contents!;
    }

    private List<UserRank> SearchUsers(List<Content> contents)
    {
        var userRanks = new List<UserRank>(); 
        var searchUserIds = contents.Select(u => u.UserId).ToList();
        foreach (var content in contents) 
        {
            var userRank = new UserRank { UserId = content.UserId! };
            var linkUserIds = content.Links!.Select(u => u.Id).ToList();           
            foreach (var linkUserId in linkUserIds)
            {      
                foreach (var searchUserId in searchUserIds)
                {
                    if (string.Compare(searchUserId, linkUserId) == 0)
                    {
                        var link = new UserRank { UserId = linkUserId! };
                        userRank.Links!.Add(link!);
                        userRanks.Add(userRank);
                    }
                }               
            }
        }
        return userRanks;
    }
}