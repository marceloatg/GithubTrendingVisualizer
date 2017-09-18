using Octokit;
using System.Collections.Generic;

namespace GithubTrendingVisualizer.Models.Repositories
{
    public class RepositoriesViewModel
    {
        public List<Repository> Repositories { get; set; }
        public Dictionary<long, bool> SavedRepositories { get; set; }
        public RateLimit RateLimit { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public Language? Language { get; set; }

        public RepositoriesViewModel()
        {
            Repositories = new List<Repository>();
            SavedRepositories = new Dictionary<long, bool>();
            RateLimit = new RateLimit();
            Page = 1;
        }
    }
}