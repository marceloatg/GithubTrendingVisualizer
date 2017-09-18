using Octokit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchRepositoriesRequest = GithubTrendingVisualizer.Services.Octokit.SearchRepositoriesRequest;

namespace GithubTrendingVisualizer.Services
{
    public class GithubServices
    {
        private GitHubClient Client { get; }
        private const int PerPage = 10;

        public GithubServices()
        {
            Client = new GitHubClient(new ProductHeaderValue("GithubTrendingVisualizer"));
        }

        public async Task<(List<Repository> repositories, RateLimit rateLimit)>
            GetTrendingRepositories(int page)
        {
            var repositories = new List<Repository>();

            var request = new SearchRepositoriesRequest
            {
                User = string.Empty,
                Fork = ForkQualifier.IncludeForks,
                SortField = RepoSearchSort.Stars,
                Order = SortDirection.Descending,
                Page = page,
                PerPage = PerPage,
            };

            SearchRepositoryResult response = await Client.Search.SearchRepo(request);
            repositories.AddRange(response.Items);

            return (repositories, GetRateLimit());
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