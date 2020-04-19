using System;
using Convey.CQRS.Queries;
using Pluralsight.Services.Courses.Application.DTO;

namespace Pluralsight.Services.Courses.Application.Queries
{
    public class GetCourseModule : IQuery<CourseModuleDto>
    {
        public Guid CourseModuleId { get; set; }
    }
}