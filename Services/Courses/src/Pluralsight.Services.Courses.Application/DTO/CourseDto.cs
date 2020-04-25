namespace Pluralsight.Services.Courses.Application.DTO
{
    using System;
    using System.Collections.Generic;

    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}