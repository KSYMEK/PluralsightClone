namespace Pluralsight.Services.Courses.Application.Queries
{
    using System;
    using Convey.CQRS.Queries;
    using DTO;

    public class GetCourseModule : IQuery<CourseModuleDto>
    {
        public Guid CourseModuleId { get; set; }
    }
}