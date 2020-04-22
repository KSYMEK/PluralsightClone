namespace Pluralsight.Services.Courses.Core.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface ICourseEpisodeRepository
    {
        Task<CourseEpisode> GetAsync(Guid episodeId);
        Task AddAsync(CourseEpisode episode, Guid moduleId);
        Task UpdateAsync(CourseEpisode episode);
        Task RemoveAsync(Guid episodeId, Guid moduleId);
    }
}