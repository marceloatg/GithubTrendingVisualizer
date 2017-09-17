using System.Collections.Generic;
using System.Globalization;

namespace GithubTrendingVisualizer.Services
{
    public class SearchRepositoriesRequest : Octokit.SearchRepositoriesRequest
    {

        public override IReadOnlyList<string> MergedQualifiers()
        {
            var parameters = new List<string>();

            if (In != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "in:{0}", string.Join(",", In)));
            }

            if (Size != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "size:{0}", Size));
            }

            if (Forks != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "forks:{0}", Forks));
            }

            if (Fork != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "fork:{0}", Fork));
            }

            if (Stars != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "stars:{0}", Stars));
            }

            if (Language != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "language:{0}", Language));
            }

            if (User != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "user:{0}", User));
            }

            if (Created != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "created:{0}", Created));
            }

            if (Updated != null)
            {
                parameters.Add(string.Format(CultureInfo.InvariantCulture, "pushed:{0}", Updated));
            }
            return parameters;
        }

    }
}