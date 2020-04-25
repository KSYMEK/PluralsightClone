namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Documents
{
    using System;
    using System.Collections.Generic;
    using Convey.Types;

    public class CourseModuleDocument : IIdentifiable<Guid>
    {
        public Guid CourseId { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid> Episodes { get; set; }
        public int ModuleOrder { get; set; }
        public Guid Id { get; set; }
    }
}