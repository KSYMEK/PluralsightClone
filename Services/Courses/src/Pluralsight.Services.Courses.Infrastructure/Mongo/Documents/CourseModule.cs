using System;
using System.Collections.Generic;
using Convey.Types;
using Pluralsight.Services.Courses.Core.Entities;
using Pluralsight.Services.Courses.Core.Exceptions;

namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Documents
{
    public class CourseModuleDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public IEnumerable<CourseEpisodeDocument> Episodes { get; set; }
        public int ModuleOrder { get; set; }
    }
}