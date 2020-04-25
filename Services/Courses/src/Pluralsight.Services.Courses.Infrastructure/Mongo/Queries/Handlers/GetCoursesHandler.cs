namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Queries.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
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

            return list.Select(course => new CourseDto
                {
                    Title = course.Title, Description = course.Description, Id = course.Id, Tags = course.Tags
                })
                .ToList();
        }
    }
}