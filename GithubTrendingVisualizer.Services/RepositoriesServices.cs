using GithubTrendingVisualizer.Models.Repositories;
using System.Threading.Tasks;

namespace GithubTrendingVisualizer.Services
{
    public class RepositoriesServices
    {
        private GithubServices GithubServices { get; }

        public RepositoriesServices()
        {
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
    }
}