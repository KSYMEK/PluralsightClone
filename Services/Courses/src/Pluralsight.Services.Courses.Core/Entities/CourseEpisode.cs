﻿namespace Pluralsight.Services.Courses.Core.Entities
{
    using System;
    using Exceptions;

    public class CourseEpisode : AggregateRoot
    {
        public CourseEpisode(Guid id, Guid moduleId, string episodeName, int episodeOrder, string episodeVideoLink,
            string description = null)
        {
            if (string.IsNullOrWhiteSpace(episodeName))
                throw new InvalidEpisodeNameException();

            if (moduleId == Guid.Empty)
                throw new InvalidModuleIdForEpisodeException(episodeName);

            if (string.IsNullOrWhiteSpace(episodeVideoLink))
                throw new InvalidEpisodeLinkException(episodeName);

            if (episodeOrder <= 0)
                throw new InvalidEpisodeOrderException(episodeName);

            Id = id;
            ModuleId = moduleId;
            EpisodeName = episodeName;
            EpisodeOrder = episodeOrder;
            EpisodeVideoLink = episodeVideoLink;
            Description = description;
        }

        public Guid ModuleId { get; }
        public string EpisodeName { get; }
        public string EpisodeVideoLink { get; }
        public string Description { get; }
        public int EpisodeOrder { get; }
    }
}