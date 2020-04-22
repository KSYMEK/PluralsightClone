namespace Pluralsight.Services.Courses.Infrastructure.Mongo.Documents
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO;
    using Core.Entities;

    public static class Extensions
    {
        public static Course AsEntity(this CourseDocument document)
        {
            return new Course(document.Id, document.Title, document.Description, document.Tags,
                document.Modules.ToEntities());
        }

        public static CourseModule AsEntity(this CourseModuleDocument document)
        {
            return new CourseModule(document.Id, document.CourseId, document.ModuleName, document.ModuleOrder,
                document.Description, document.Episodes.ToEntities());
        }

        public static CourseEpisode AsEntity(this CourseEpisodeDocument document)
        {
            return new CourseEpisode(document.Id, document.ModuleId, document.EpisodeName, document.EpisodeOrder,
                document.EpisodeVideoLink, document.Description);
        }

        public static CourseDto AsDto(this CourseDocument document)
        {
            return new CourseDto
            {
                Id = document.Id,
                CourseModules = document.Modules.AsDtos(),
                Tags = document.Tags
            };
        }

        public static CourseModuleDto AsDto(this CourseModuleDocument document)
        {
            return new CourseModuleDto
            {
                Id = document.Id,
                CourseEpisodes = document.Episodes.AsDtos(),
                Description = document.Description,
                ModuleName = document.ModuleName
            };
        }

        public static CourseEpisodeDto AsDto(this CourseEpisodeDocument document)
        {
            return new CourseEpisodeDto
            {
                Id = document.Id,
                Description = document.Description,
                EpisodeName = document.EpisodeName,
                EpisodeVideoLink = document.EpisodeVideoLink
            };
        }

        public static IEnumerable<CourseModuleDto> AsDtos(this IEnumerable<CourseModuleDocument> documents)
        {
            return documents.Select(document => document.AsDto());
        }

        public static IEnumerable<CourseEpisodeDto> AsDtos(this IEnumerable<CourseEpisodeDocument> documents)
        {
            return documents.Select(document => document.AsDto());
        }

        public static IEnumerable<CourseEpisode> ToEntities(this IEnumerable<CourseEpisodeDocument> list)
        {
            return list.Select(document => document.AsEntity()).ToList();
        }

        public static IEnumerable<CourseModule> ToEntities(this IEnumerable<CourseModuleDocument> list)
        {
            return list.Select(document => document.AsEntity()).ToList();
        }

        public static CourseDocument AsDocument(this Course entity)
        {
            return new CourseDocument
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                Description = entity.Description,
                Modules = entity.Modules.AsDocuments(),
                Tags = entity.Tags,
                Title = entity.Title
            };
        }

        public static CourseModuleDocument AsDocument(this CourseModule entity)
        {
            return new CourseModuleDocument
            {
                Id = entity.Id,
                CourseId = entity.CourseId,
                Description = entity.Description,
                Episodes = entity.Episodes.AsDocuments(),
                ModuleName = entity.ModuleName,
                ModuleOrder = entity.ModuleOrder
            };
        }

        public static CourseEpisodeDocument AsDocument(this CourseEpisode entity)
        {
            return new CourseEpisodeDocument
            {
                Id = entity.Id,
                Description = entity.Description,
                EpisodeName = entity.EpisodeName,
                EpisodeOrder = entity.EpisodeOrder,
                EpisodeVideoLink = entity.EpisodeVideoLink,
                ModuleId = entity.ModuleId
            };
        }

        public static IEnumerable<CourseEpisodeDocument> AsDocuments(this IEnumerable<CourseEpisode> entities)
        {
            return entities.Select(entity => entity.AsDocument());
        }

        public static IEnumerable<CourseModuleDocument> AsDocuments(this IEnumerable<CourseModule> entities)
        {
            return entities.Select(entity => entity.AsDocument());
        }
    }
}