using System.Threading.Tasks;
using GithubTrendingVisualizer.Models.Repositories;
using GithubTrendingVisualizer.Services;
using Microsoft.AspNetCore.Mvc;

namespace GithubTrendingVisualizer.Web.Controllers
{
    [Route("[controller]")]
    public class RepositoriesController : Controller
    {
        private RepositoriesServices RepositoriesServices { get; }

        public RepositoriesController()
        {
            RepositoriesServices = new RepositoriesServices();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RepositoriesViewModel model = await RepositoriesServices.CreateRepositoriesViewModel();
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
