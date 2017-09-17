﻿using Octokit;
using System.Collections.Generic;

namespace GithubTrendingVisualizer.Models.Repositories
{
    public class RepositoriesViewModel
    {
        public List<Repository> Repositories { get; set; }
        public Dictionary<long, bool> SavedRepositories { get; set; }
        public RateLimit RateLimit { get; set; }

        public RepositoriesViewModel()
        {
            Repositories = new List<Repository>();
            SavedRepositories = new Dictionary<long, bool>();
            RateLimit = new RateLimit();
        }
    }
}