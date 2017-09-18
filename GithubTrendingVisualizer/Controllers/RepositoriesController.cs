using System.Threading.Tasks;
using GithubTrendingVisualizer.Data.Models;
using GithubTrendingVisualizer.Models.Repositories;
using GithubTrendingVisualizer.Services;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using Repository = GithubTrendingVisualizer.Data.Models.Repository;

namespace GithubTrendingVisualizer.Web.Controllers
{
    [Route("[controller]")]
    public class RepositoriesController : Controller
    {
        private Context Context { get; }
        private RepositoriesServices RepositoriesServices { get; }

        public RepositoriesController(Context context)
        {
            Context = context;
            RepositoriesServices = new RepositoriesServices(Context);
        }

        [HttpGet]
        public async Task<IActionResult> Trending([FromQuery] int page, [FromQuery] Language? language = null)
        {
            RepositoriesViewModel model = await RepositoriesServices.CreateRepositoriesViewModel(page, language);
            return View(model);
        }

        [HttpPost]
        [Route("[action]")]
        public JsonResult SaveRepository([FromBody] Repository repository)
        {
            bool succeeded = RepositoriesServices.SaveRepository(repository);
            return Json(succeeded);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Saved()
        {
            return View();
        }
    }
}
