using GithubTrendingVisualizer.Data.Models;

namespace GithubTrendingVisualizer.Data.Repositories
{
    public class RepositoryRepository : Repository<Repository>
    {
        public RepositoryRepository(Context context) : base(context)
        {
        }
    }
}