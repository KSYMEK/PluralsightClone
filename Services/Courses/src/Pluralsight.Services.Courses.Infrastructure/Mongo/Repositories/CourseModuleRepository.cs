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

    public class CourseModuleRepository : ICourseModuleRepository
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMongoRepository<CourseModuleDocument, Guid> _repository;

        public CourseModuleRepository(IMongoRepository<CourseModuleDocument, Guid> repository,
            ICourseRepository courseRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
        }

        public async Task<CourseModule> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);
            return result.AsEntity();
        }

        public async Task<IEnumerable<CourseModule>> GetAllAsync(Guid courseId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            var list = new List<CourseModule>();

            foreach (var guid in course.Modules)
            {
                var module = await GetAsync(guid);
                list.Add(module);
            }

            return list;
        }

        public async Task AddAsync(CourseModule courseModule, Guid courseId)
        {
            await _repository.AddAsync(courseModule.AsDocument());
            var course = await _courseRepository.GetAsync(courseId);
            course.Modules = course.Modules.Append<Guid>(courseModule.Id);
            await _courseRepository.UpdateAsync(course);
        }

        public async Task UpdateAsync(CourseModule courseModule)
        {
            await _repository.UpdateAsync(courseModule.AsDocument());
        }

        public async Task RemoveAsync(Guid id, Guid courseId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            var courseModule = await _repository.GetAsync(id);
            course.Modules.ToList().Remove(courseModule.Id);
            await _courseRepository.UpdateAsync(course);
            await _repository.DeleteAsync(id);
        }
    }
}