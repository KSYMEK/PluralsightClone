namespace Pluralsight.Services.Courses.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    public class Course : AggregateRoot
    {
        public Course(Guid id, string title, string description, IEnumerable<string> tags,
            IEnumerable<CourseModule> modules)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new InvalidCourseTitleException();

            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidCourseDescriptionException();

            Id = id;
            Title = title;
            Description = description;
            var courseModules = modules.ToList();
            Modules = courseModules.Any() ? courseModules : new List<CourseModule>();
            Tags = tags;
            CreatedAt = DateTime.UtcNow;
        }

        public string Title { get; }
        public string Description { get; }
        public IEnumerable<CourseModule> Modules { get; }
        public DateTime CreatedAt { get; }
        public IEnumerable<string> Tags { get; }
    }
}