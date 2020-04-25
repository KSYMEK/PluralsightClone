namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Convey.Persistence.MongoDB;
    using Core.Entities;
    using Core.Repositories;
    using Documents;

    public class CourseRepository : ICourseRepository
    {
        private readonly IMongoRepository<CourseDocument, Guid> _repository;

        public CourseRepository(IMongoRepository<CourseDocument, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var result = await _repository.FindAsync(_ => true);
            var list = result.Select(document => document.AsEntity()).ToList();
            return list;
        }

        public async Task<Course> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return result.AsEntity();
        }

        public async Task AddAsync(Course course)
        {
            await _repository.AddAsync(course.AsDocument());
        }

        public async Task UpdateAsync(Course course)
        {
            await _repository.UpdateAsync(course.AsDocument());
        }

        public async Task RemoveAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}