namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Queries.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Queries;
    using Convey.CQRS.Queries;
    using Core.Repositories;

    public class GetCourseModulesHandler : IQueryHandler<GetCourseModules, IEnumerable<CourseModuleDto>>
    {
        private readonly ICourseModuleRepository _repository;

        public GetCourseModulesHandler(ICourseModuleRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<CourseModuleDto>> HandleAsync(GetCourseModules query)
        {
            var result = await _repository.GetAllAsync(query.CourseId);
            var list = new List<CourseModuleDto>();

            foreach (var courseModule in result)
            {
                var episodesDto = new List<CourseEpisodeDto>();
                foreach (var episode in courseModule.Episodes)
                {
                    var eDto = new CourseEpisodeDto
                    {
                        EpisodeName = episode.EpisodeName,
                        Description = episode.Description,
                        Id = episode.Id,
                        EpisodeVideoLink = episode.EpisodeVideoLink
                    };
                    episodesDto.Add(eDto);
                }

                var dto = new CourseModuleDto()
                {
                    Id = courseModule.Id,
                    Description = courseModule.Description,
                    ModuleName = courseModule.ModuleName,
                    CourseEpisodes = episodesDto
                };
                list.Add(dto);
            }

            return list;
        }
    }
}