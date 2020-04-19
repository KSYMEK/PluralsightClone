using System;
using Convey.CQRS.Queries;
using Pluralsight.Services.Courses.Application.DTO;

namespace Pluralsight.Services.Courses.Application.Queries
{
    public class GetCourse : IQuery<CourseDto>
    {
        public Guid CourseId { get; set; }
    }
}