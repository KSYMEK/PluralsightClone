namespace Pluralsight.Services.Courses.Application.DTO
{
    using System;
    using System.Collections.Generic;

    public class CourseModuleDto
    {
        public Guid Id { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public IEnumerable<CourseEpisodeDto> CourseEpisodes { get; set; }
    }
}