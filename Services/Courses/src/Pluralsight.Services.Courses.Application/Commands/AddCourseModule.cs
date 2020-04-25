namespace Pluralsight.Services.Courses.Application.Commands
{
    using System;
    using Convey.CQRS.Commands;

    [Contract]
    public class AddCourseModule : ICommand
    {
        public AddCourseModule(Guid courseId, Guid moduleId, string moduleName, string description, int moduleOrder)
        {
            CourseId = courseId;
            ModuleId = moduleId == Guid.Empty ? Guid.NewGuid() : moduleId;
            ModuleName = moduleName;
            Description = description;
            ModuleOrder = moduleOrder;
        }

        public Guid CourseId { get; }
        public Guid ModuleId { get; }
        public string ModuleName { get; }
        public string Description { get; }
        public int ModuleOrder { get; }
    }
}