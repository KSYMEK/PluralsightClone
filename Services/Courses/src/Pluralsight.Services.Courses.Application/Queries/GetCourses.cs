namespace Pluralsight.Services.Courses.Application.Queries
{
    using System.Collections.Generic;
    using Convey.CQRS.Queries;
    using DTO;

    public class GetCourses : IQuery<IEnumerable<CourseDto>>
    {
    }
}