using System.Collections.Generic;
using Repository = GithubTrendingVisualizer.Data.Models.Repository;

namespace GithubTrendingVisualizer.Models.Repositories
{
    public class SavedRepositoriesViewModel
    {
        public List<Repository> Repositories { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public string Language { get; set; }

        public SavedRepositoriesViewModel()
        {
            Repositories = new List<Repository>();
            Page = 1;
        }
    }
}