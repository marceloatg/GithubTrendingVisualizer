using System;

namespace GithubTrendingVisualizer.Data.Models
{
    public class Repository : IEntity
    {
        public Guid Id { get; set; }

        public long GithubId { get; set; }

        public string Name { get; set; }

        public string HtmlUrl { get; set; }

        public int ForksCount { get; set; }

        public int StargazersCount { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        /// <summary>
        /// The account's full name.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// The HTML URL for the account on github.com (or GitHub Enterprise).
        /// </summary>
        public string OwnerHtmlUrl { get; set; }

        /// <summary>
        /// URL of the account's avatar.
        /// </summary>
        public string OwnerAvatarUrl { get; set; }

    }
}