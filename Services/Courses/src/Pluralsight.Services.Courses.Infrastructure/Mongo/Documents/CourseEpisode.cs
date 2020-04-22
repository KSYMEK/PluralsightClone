namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Documents
{
    using System;
    using Convey.Types;

    public class CourseEpisodeDocument : IIdentifiable<Guid>
    {
        public Guid ModuleId { get; set; }
        public string EpisodeName { get; set; }
        public string EpisodeVideoLink { get; set; }
        public string Description { get; set; }
        public int EpisodeOrder { get; set; }
        public Guid Id { get; set; }
    }
}