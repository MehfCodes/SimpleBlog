using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Repository;

namespace SimpleBlog.Controllers;

public class HomeController : Controller
{
    private readonly IPostRepository postRepository;

    public HomeController(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await postRepository.GetRecentPostsAsync();
        return View(posts);
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
