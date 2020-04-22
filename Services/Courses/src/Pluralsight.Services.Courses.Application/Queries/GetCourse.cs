namespace Pluralsight.Services.Courses.Application.Queries
{
    using System;
    using Convey.CQRS.Queries;
    using DTO;

    public class GetCourse : IQuery<CourseDto>
    {
        public Guid CourseId { get; set; }
    }
}