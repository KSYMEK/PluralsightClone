namespace Pluralsight.Services.Courses.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface ICourseRepository
    {
        Task<Course> GetAsync(Guid id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task RemoveAsync(Guid id);
    }
}