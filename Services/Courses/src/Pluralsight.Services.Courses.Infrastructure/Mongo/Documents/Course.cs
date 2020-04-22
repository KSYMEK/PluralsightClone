namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Documents
{
    using System;
    using System.Collections.Generic;
    using Convey.Types;

    public class CourseDocument : IIdentifiable<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<CourseModuleDocument> Modules { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Guid Id { get; set; }
    }
}