namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Queries.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Queries;
    using Convey.CQRS.Queries;
    using Core.Repositories;

    public class GetCoursesHandler : IQueryHandler<GetCourses, IEnumerable<CourseDto>>
    {
        private readonly ICourseRepository _repository;

        public GetCoursesHandler(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CourseDto>> HandleAsync(GetCourses query)
        {
            var list = await _repository.GetAllAsync();
            var result = new List<CourseDto>();
            foreach (var course in list)
            {
                var episodes = new List<CourseEpisodeDto>();
                var modules = new List<CourseModuleDto>();
                foreach (var module in course.Modules)
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
                        Description = course.Description,
                        CourseEpisodes = episodes,
                        Id = module.Id
                    };
                    modules.Add(mDto);
                }
                
                var dto = new CourseDto
                {
                    CourseModules = modules,
                    Title = course.Title,
                    Description = course.Description,
                    Id = course.Id,
                    Tags = course.Tags,
                };
                
                result.Add(dto);
            }

            return result;
        }
    }
}