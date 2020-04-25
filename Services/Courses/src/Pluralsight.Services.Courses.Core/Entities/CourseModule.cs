namespace Pluralsight.Services.Courses.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using Exceptions;

    public class CourseModule : AggregateRoot
    {
        public CourseModule(Guid id, Guid courseId, string moduleName, int moduleOrder, string description,
            IEnumerable<Guid> episodes = null)
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
            Episodes = episodes ?? new List<Guid>();
        }

        public Guid CourseId { get; }
        public string ModuleName { get; }
        public string Description { get; }
        public IEnumerable<Guid> Episodes { get; }
        public int ModuleOrder { get; }
    }
}