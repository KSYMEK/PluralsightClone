namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Queries.Handlers
{
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
            var dto = new CourseDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Tags = result.Tags
            };

            return dto;
        }
    }
}