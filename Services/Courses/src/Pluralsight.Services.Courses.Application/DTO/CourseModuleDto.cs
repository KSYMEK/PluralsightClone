namespace Pluralsight.Services.Courses.Application.DTO
{
    using System;

    public class CourseModuleDto
    {
        public Guid Id { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
    }
}