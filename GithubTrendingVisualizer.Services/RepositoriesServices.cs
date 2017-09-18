using GithubTrendingVisualizer.Models.Repositories;
using System.Threading.Tasks;
using GithubTrendingVisualizer.Data.Models;
using GithubTrendingVisualizer.Data.Repositories;

namespace GithubTrendingVisualizer.Services
{
    public class RepositoriesServices
    {
        private Context Context { get; }
        private GithubServices GithubServices { get; }

        public RepositoriesServices(Context context)
        {
            Context = context;
            GithubServices = new GithubServices();
        }

        public async Task<RepositoriesViewModel> CreateRepositoriesViewModel(int page)
        {
            if (page < 1) { page = 1; }
            if (page > 100) { page = 100; }

            var repositoriesResponse = await GithubServices.GetTrendingRepositories(page);

            var model = new RepositoriesViewModel
            {
                Repositories = repositoriesResponse.repositories,
                RateLimit = repositoriesResponse.rateLimit,
                Page = page
            };

            return model;
        }

        public bool SaveRepository(Repository repository)
        {
            var insertion = new RepositoryRepository(Context).Insert(repository);
            return insertion.succeeded;
        }
    }
}