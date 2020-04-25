namespace Pluralsight.Services.Courses.Application.Commands
{
    using System;
    using Convey.CQRS.Commands;

    [Contract]
    public class AddCourseModuleEpisode : ICommand
    {
        public AddCourseModuleEpisode(Guid courseId, Guid moduleId, Guid episodeId, string episodeName,
            string episodeVideoLink, string description, int episodeOrder)
        {
            CourseId = courseId;
            ModuleId = moduleId;
            EpisodeId = episodeId == Guid.Empty ? Guid.NewGuid() : episodeId;
            EpisodeName = episodeName;
            EpisodeVideoLink = episodeVideoLink;
            Description = description;
            EpisodeOrder = episodeOrder;
        }

        public Guid CourseId { get; }
        public Guid ModuleId { get; }
        public Guid EpisodeId { get; }
        public string EpisodeName { get; }
        public string EpisodeVideoLink { get; }
        public string Description { get; }
        public int EpisodeOrder { get; }
    }
}