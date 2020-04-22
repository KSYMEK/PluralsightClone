namespace Pluralsight.Services.Courses.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface ICourseModuleRepository
    {
        Task<CourseModule> GetAsync(Guid id);
        Task<IEnumerable<CourseModule>> GetAllAsync(Guid courseId);
        Task AddAsync(CourseModule courseModule, Guid courseId);
        Task UpdateAsync(CourseModule courseModule);
        Task RemoveAsync(Guid id, Guid courseId);
    }
}