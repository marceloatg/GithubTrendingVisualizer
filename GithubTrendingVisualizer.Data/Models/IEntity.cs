using System;

namespace GithubTrendingVisualizer.Data.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}