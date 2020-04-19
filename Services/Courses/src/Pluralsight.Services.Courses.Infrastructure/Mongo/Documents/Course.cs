using System;
using System.Collections.Generic;
using Convey.Types;

namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Documents
{
    public class CourseDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<CourseModuleDocument> Modules { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}