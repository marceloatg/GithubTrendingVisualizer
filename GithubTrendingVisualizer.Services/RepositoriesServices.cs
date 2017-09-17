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

        public async Task<RepositoriesViewModel> CreateRepositoriesViewModel()
        {
            var repositoriesResponse = await GithubServices.GetTrendingRepositories();

            var model = new RepositoriesViewModel
            {
                Repositories = repositoriesResponse.repositories,
                RateLimit = repositoriesResponse.rateLimit
            };

            return model;
        }
    }
}