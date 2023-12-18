using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialRank.Areas.Identity.Data;
using SocialRank.Data;
using SocialRank.Models;

namespace SocialRank.Controllers;

[Authorize]
public class ContentsController : Controller
{
    private readonly SocialRankContext _context;
    private readonly UserManager<SocialRankUser> _userManager;

    public ContentsController(SocialRankContext context, UserManager<SocialRankUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
          return _context.Contents != null ? 
                      View(await _context.Contents.ToListAsync()) :
                      Problem("Entity set 'SocialRankContext.Contents'  is null.");
    }

    public async Task<IActionResult> Details(string id)
    {
        var content = await _context.Contents.FirstOrDefaultAsync(m => m.Id == id);
        return View(content);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Description")] Content content)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            content.UserId = user!.Id;
            _context.Add(content);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(content);
    }

    public async Task<IActionResult> Delete(string id)
    {       
        var content = await _context.Contents.FirstOrDefaultAsync(m => m.Id == id);       
        return View(content);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var content = await _context.Contents.FindAsync(id);
        if (content != null)
        {
            _context.Contents.Remove(content);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ActionName("Endorse")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Endorse(string id)
    {
        var user = await _userManager.GetUserAsync(User);
        var content = await _context.Contents.FirstOrDefaultAsync(m => m.Id == id);
        content!.Links!.Add(user!);
        return RedirectToAction(nameof(Index));
    }

    private bool ContentExists(string id)
    {
      return (_context.Contents?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}