using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Pluralsight.Services.Courses.Core.Entities;
using Pluralsight.Services.Courses.Core.Repositories;
using Pluralsight.Services.Courses.Infrastructure.Mongo.Documents;

namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Repositories
{
    public class CourseEpisodeRepository : ICourseEpisodeRepository
    {
        private readonly IMongoRepository<CourseEpisodeDocument, Guid> _repository;

        public CourseEpisodeRepository(IMongoRepository<CourseEpisodeDocument, Guid> repository)
        {
            _repository = repository;
        }
        
        public async Task<CourseEpisode> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return result.AsEntity();
        }

        public async Task AddAsync(Guid moduleId, CourseEpisode course) => 

        public async Task UpdateAsync(Guid moduleId, CourseEpisode course)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}