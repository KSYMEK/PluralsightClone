using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Pluralsight.Services.Courses.Core.Entities;
using Pluralsight.Services.Courses.Core.Repositories;
using Pluralsight.Services.Courses.Infrastructure.Mongo.Documents;

namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Repositories
{
    public class CourseModuleRepository : ICourseModuleRepository
    {
        private readonly IMongoRepository<CourseModuleDocument, Guid> _repository;

        public CourseModuleRepository(IMongoRepository<CourseModuleDocument, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<CourseModule> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return result.AsEntity();
        }

        public async Task AddAsync(CourseModule courseModule) => await _repository.AddAsync(courseModule.AsDocument());

        public async Task UpdateAsync(CourseModule courseModule) => await _repository.UpdateAsync(courseModule.AsDocument());

        public async Task RemoveAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}