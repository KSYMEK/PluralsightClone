using System;
using System.Collections.Generic;

namespace Pluralsight.Services.Courses.Application.DTO
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; }
        public string Description { get; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<CourseModuleDto> CourseModules { get; set; }
    }
}