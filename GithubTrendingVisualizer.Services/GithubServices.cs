using Octokit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubTrendingVisualizer.Services
{
    public class GithubServices
    {
        private GitHubClient Client { get; }

        public GithubServices()
        {
            Client = new GitHubClient(new ProductHeaderValue("GithubTrendingVisualizer"));
        }

        public async Task<(List<Repository> repositories, RateLimit rateLimit)>
            GetTrendingRepositories(int page = 1, int perPage = 10)
        {
            var repositories = new List<Repository>();

            var request = new SearchRepositoriesRequest
            {
                User = string.Empty,
                SortField = RepoSearchSort.Stars,
                Order = SortDirection.Descending,
                Page = page,
                PerPage = perPage,
            };

            try
            {
                SearchRepositoryResult response = await Client.Search.SearchRepo(request);
                repositories.AddRange(response.Items);

                return (repositories, GetRateLimit());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void GetTrendingDevelopers()
        {

        }

        private RateLimit GetRateLimit()
        {
            ApiInfo apiInfo = Client.GetLastApiInfo();
            RateLimit rateLimit = apiInfo?.RateLimit;

            return rateLimit;
        }
    }
}