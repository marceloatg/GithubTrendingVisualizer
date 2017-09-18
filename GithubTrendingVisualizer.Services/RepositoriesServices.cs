using System;
using GithubTrendingVisualizer.Data.Models;
using GithubTrendingVisualizer.Data.Repositories;
using GithubTrendingVisualizer.Models.Repositories;
using Octokit;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository = GithubTrendingVisualizer.Data.Models.Repository;

namespace GithubTrendingVisualizer.Services
{
    public class RepositoriesServices
    {
        private Context Context { get; }
        private GithubServices GithubServices { get; }
        private const int PageSize = 10;

        public RepositoriesServices(Context context)
        {
            Context = context;
            GithubServices = new GithubServices();
        }

        public async Task<RepositoriesViewModel> CreateRepositoriesViewModel(int page, Language? language)
        {
            if (page < 1) { page = 1; }
            if (page > 100) { page = 100; }

            // reading from Github
            var repositoriesResponse = await GithubServices.GetTrendingRepositories(page, language);
            var savedRepositories = repositoriesResponse.repositories.ToDictionary(repository => repository.Id, repository => false);

            // reading from database
            var savedRepositoriesReading =
                new RepositoryRepository(Context)
                    .List(repository => savedRepositories.Keys.Contains(repository.GithubId));

            if (savedRepositoriesReading.entities == null) { return null; }
            foreach (Repository repository in savedRepositoriesReading.entities)
            {
                savedRepositories[repository.GithubId] = true;
            }

            var model = new RepositoriesViewModel
            {
                Repositories = repositoriesResponse.repositories,
                RateLimit = repositoriesResponse.rateLimit,
                Page = page,
                TotalCount = repositoriesResponse.totalCount,
                Language = language,
                SavedRepositories = savedRepositories
            };

            return model;
        }

        public SavedRepositoriesViewModel CreateSavedViewModel(int page, string language)
        {
            if (page < 1) { page = 1; }

            Expression<Func<Repository, bool>> predicate = repository => true;
            if (!string.IsNullOrWhiteSpace(language)) { predicate = repository => repository.Language == language; }

            var repositoriesReading = new RepositoryRepository(Context).List(predicate);

            var model = new SavedRepositoriesViewModel
            {
                Repositories = repositoriesReading.entities.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                Page = page,
                TotalCount = repositoriesReading.entities.Count(),
                Language = language,
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