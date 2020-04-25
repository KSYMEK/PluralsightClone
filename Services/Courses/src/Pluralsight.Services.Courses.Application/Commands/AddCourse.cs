namespace Pluralsight.Services.Courses.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using Convey.CQRS.Commands;

    [Contract]
    public class AddCourse : ICommand
    {
        public AddCourse(Guid courseId, string title, string description, IEnumerable<string> tags)
        {
            CourseId = courseId == Guid.Empty ? Guid.NewGuid() : courseId;
            Title = title;
            Description = description;
            Tags = tags;
        }

        public Guid CourseId { get; }
        public string Title { get; }
        public string Description { get; }
        public IEnumerable<string> Tags { get; }
    }
}