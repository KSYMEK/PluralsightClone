namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Queries.Handlers
{
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Queries;
    using Convey.CQRS.Queries;
    using Core.Repositories;

    public class GetCourseModuleHandler : IQueryHandler<GetCourseModule, CourseModuleDto>
    {
        private readonly ICourseModuleRepository _repository;

        public GetCourseModuleHandler(ICourseModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<CourseModuleDto> HandleAsync(GetCourseModule query)
        {
            var result = await _repository.GetAsync(query.CourseModuleId);
            var dto = new CourseModuleDto
            {
                Id = result.Id,
                Description = result.Description,
                ModuleName = result.ModuleName
            };
            return dto;
        }
    }
}