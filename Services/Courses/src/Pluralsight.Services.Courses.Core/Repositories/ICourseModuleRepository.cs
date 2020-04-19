using System;
using System.Threading.Tasks;
using Pluralsight.Services.Courses.Core.Entities;

namespace Pluralsight.Services.Courses.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetAsync(Guid id);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task RemoveAsync(Guid id);
    }
}