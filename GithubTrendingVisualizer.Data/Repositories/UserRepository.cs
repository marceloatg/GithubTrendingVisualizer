using GithubTrendingVisualizer.Data.Models;

namespace GithubTrendingVisualizer.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}