﻿namespace Pluralsight.Services.Courses.Application.DTO
{
    using System;

    public class CourseEpisodeDto
    {
        public Guid Id { get; set; }
        public string EpisodeName { get; set; }
        public string EpisodeVideoLink { get; set; }
        public string Description { get; set; }
    }
}