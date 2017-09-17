using GithubTrendingVisualizer.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GithubTrendingVisualizer.Web.Controllers
{
    [Route("[controller]")]
    public class RepositoriesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new RepositoriesViewModel();

            return View(model);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Saved()
        {
            return View();
        }
    }
}
