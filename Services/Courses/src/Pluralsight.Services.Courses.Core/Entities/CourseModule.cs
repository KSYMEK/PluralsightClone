using System;
using System.Collections.Generic;
using Pluralsight.Services.Courses.Core.Exceptions;

namespace Pluralsight.Services.Courses.Core.Entities
{
    public class CourseModule : AggregateRoot
    {
        public Guid CourseId { get; }
        public string ModuleName { get; }
        
        public string Description { get; }
        public IEnumerable<CourseEpisode> Episodes { get; }
        public int ModuleOrder { get; }

        public CourseModule(Guid id, Guid courseId, string moduleName, int moduleOrder, string description, IEnumerable<CourseEpisode> episodes = null)
        {
            if (string.IsNullOrWhiteSpace(moduleName))
                throw new InvalidModuleNameException();

            if (courseId == Guid.Empty)
                throw new InvalidCourseIdForModuleException(moduleName);

            if (moduleOrder <= 0)
                throw new InvalidModuleOrderValueException(moduleName);
            
            Id = id;
            CourseId = courseId;
            Description = description;
            ModuleName = moduleName;
            ModuleOrder = moduleOrder;
            Episodes = episodes ?? new List<CourseEpisode>();
        }
    }
}