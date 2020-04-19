using System;
using Convey.Types;
using Pluralsight.Services.Courses.Core.Entities;
using Pluralsight.Services.Courses.Core.Exceptions;

namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Documents
{
    public class CourseEpisodeDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public string EpisodeName { get; set; }
        public string EpisodeVideoLink { get; set; }
        public string Description { get; set; }
        public int EpisodeOrder { get; set; }
    }
}