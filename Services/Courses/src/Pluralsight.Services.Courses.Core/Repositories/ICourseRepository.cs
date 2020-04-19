using System;
using System.Threading.Tasks;
using Pluralsight.Services.Courses.Core.Entities;

namespace Pluralsight.Services.Courses.Core.Repositories
{
    public interface ICourseModuleRepository
    {
        Task<CourseModule> GetAsync(Guid id);
        Task AddAsync(CourseModule courseModule);
        Task UpdateAsync(CourseModule courseModule);
        Task RemoveAsync(Guid id);
    }
}