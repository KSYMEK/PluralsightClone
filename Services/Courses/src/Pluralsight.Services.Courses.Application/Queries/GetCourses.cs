using System.Collections.Generic;
using Convey.CQRS.Queries;
using Pluralsight.Services.Courses.Application.DTO;

namespace Pluralsight.Services.Courses.Application.Queries
{
    public class GetCourses : IQuery<IEnumerable<CourseDto>>
    {
    }
}