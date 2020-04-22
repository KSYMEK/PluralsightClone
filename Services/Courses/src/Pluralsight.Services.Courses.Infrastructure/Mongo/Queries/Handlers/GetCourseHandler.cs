namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Queries.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Queries;
    using Convey.CQRS.Queries;
    using Core.Repositories;

    public class GetCourseHandler : IQueryHandler<GetCourse, CourseDto>
    {
        private readonly ICourseRepository _repository;

        public GetCourseHandler(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<CourseDto> HandleAsync(GetCourse query)
        {
            var result = await _repository.GetAsync(query.CourseId);
            
            var episodes = new List<CourseEpisodeDto>();
            var modules = new List<CourseModuleDto>();
            foreach (var module in result.Modules)
            {
                foreach (var episode in module.Episodes)
                {
                    var eDto = new CourseEpisodeDto
                    {
                        Description = episode.Description,
                        EpisodeName = episode.EpisodeName,
                        EpisodeVideoLink = episode.EpisodeVideoLink,
                        Id = episode.Id
                    };
                    episodes.Add(eDto);
                }

                var mDto = new CourseModuleDto
                {
                    ModuleName = module.ModuleName,
                    Description = result.Description,
                    CourseEpisodes = episodes,
                    Id = module.Id
                };
                modules.Add(mDto);
            }
                
            var dto = new CourseDto
            {
                CourseModules = modules,
                Id = result.Id,
                Tags = result.Tags
            };

            return dto;
        }
    }
}