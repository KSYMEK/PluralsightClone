namespace Pluralsight.Services.Courses.Application.Commands.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Convey.CQRS.Commands;
    using Core.Entities;
    using Core.Repositories;

    public class AddCourseModuleHandler : ICommandHandler<AddCourseModule>
    {
        private readonly ICourseModuleRepository _repository;

        public AddCourseModuleHandler(ICourseModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddCourseModule command)
        {
            var courseModule = new CourseModule(command.ModuleId, command.CourseId, command.ModuleName,
                command.ModuleOrder, command.Description, new List<Guid>());
            await _repository.AddAsync(courseModule, command.CourseId);
        }
    }
}