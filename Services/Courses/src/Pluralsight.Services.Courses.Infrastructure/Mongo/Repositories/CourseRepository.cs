using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Pluralsight.Services.Courses.Core.Entities;
using Pluralsight.Services.Courses.Core.Repositories;
using Pluralsight.Services.Courses.Infrastructure.Mongo.Documents;

namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IMongoRepository<CourseDocument, Guid> _repository;

        public CourseRepository(IMongoRepository<CourseDocument, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<Course> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return result.AsEntity();
        }

        public async Task AddAsync(Course course) => await _repository.AddAsync(course.AsDocument());

        public async Task UpdateAsync(Course course) => await _repository.UpdateAsync(course.AsDocument());

        public async Task RemoveAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}