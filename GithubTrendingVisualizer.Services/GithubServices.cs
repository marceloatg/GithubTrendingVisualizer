using Octokit;
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

        public async Task<(List<Repository> repositories, int totalCount, RateLimit rateLimit)>
            GetTrendingRepositories(int page, Language? language)
        {
            var request = new SearchRepositoriesRequest
            {
                User = string.Empty,
                Fork = ForkQualifier.IncludeForks,
                SortField = RepoSearchSort.Stars,
                Order = SortDirection.Descending,
                Page = page,
                PerPage = PerPage,
            };

            if (language != null)
            {
                request.Language = language;
                request.User = null;
            }

            SearchRepositoryResult response;

            try
            {
                response = await Client.Search.SearchRepo(request);
            }
            catch (ApiValidationException)
            {
                request.Language = null;
                request.User = string.Empty;

                response = await Client.Search.SearchRepo(request);
            }

            var repositories = new List<Repository>();
            repositories.AddRange(response.Items);
            return (repositories, response.TotalCount, GetRateLimit());
        }
        
        private RateLimit GetRateLimit()
        {
            ApiInfo apiInfo = Client.GetLastApiInfo();
            RateLimit rateLimit = apiInfo?.RateLimit;

            return rateLimit;
        }
    }
}