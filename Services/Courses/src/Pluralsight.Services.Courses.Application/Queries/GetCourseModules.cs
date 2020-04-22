namespace Pluralsight.Services.Courses.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using Convey.CQRS.Queries;
    using DTO;

    public class GetCourseModules : IQuery<IEnumerable<CourseModuleDto>>
    {
        public Guid CourseId { get; set; }
    }
}