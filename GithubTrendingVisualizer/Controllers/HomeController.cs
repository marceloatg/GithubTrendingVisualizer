using System.Diagnostics;
using GithubTrendingVisualizer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GithubTrendingVisualizer.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
