namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Convey.Persistence.MongoDB;
    using Core.Entities;
    using Core.Repositories;
    using Documents;

    public class CourseEpisodeRepository : ICourseEpisodeRepository
    {
        private readonly ICourseModuleRepository _moduleRepository;
        private readonly IMongoRepository<CourseEpisodeDocument, Guid> _repository;

        public CourseEpisodeRepository(IMongoRepository<CourseEpisodeDocument, Guid> repository,
            ICourseModuleRepository moduleRepository)
        {
            _repository = repository;
            _moduleRepository = moduleRepository;
        }

        public async Task<CourseEpisode> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return result.AsEntity();
        }

        public async Task AddAsync(CourseEpisode episode, Guid moduleId)
        {
            var module = await _moduleRepository.GetAsync(moduleId);
            module.Episodes.ToList().Add(episode);
            await _repository.AddAsync(episode.AsDocument());
            await _moduleRepository.UpdateAsync(module);
        }

        public async Task UpdateAsync(CourseEpisode episode)
        {
            await _repository.UpdateAsync(episode.AsDocument());
        }


        public async Task RemoveAsync(Guid id, Guid moduleId)
        {
            var module = await _moduleRepository.GetAsync(moduleId);
            var episode = await _repository.GetAsync(id);
            module.Episodes.ToList().Remove(episode.AsEntity());
            await _repository.DeleteAsync(id);
            await _moduleRepository.UpdateAsync(module);
        }
    }
}