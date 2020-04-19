using System;
using System.Threading.Tasks;
using Pluralsight.Services.Courses.Core.Entities;

namespace Pluralsight.Services.Courses.Core.Repositories
{
    public interface ICourseEpisodeRepository
    {
        Task<CourseEpisode> GetAsync(Guid id);
        Task AddAsync(Guid moduleId, CourseEpisode course);
        Task UpdateAsync(Guid moduleId, CourseEpisode course);
        Task RemoveAsync(Guid id);
    }
}