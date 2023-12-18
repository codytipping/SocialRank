using Microsoft.AspNetCore.Mvc;

namespace SocialRank.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}