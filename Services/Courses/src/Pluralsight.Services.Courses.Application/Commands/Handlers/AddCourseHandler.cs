namespace Pluralsight.Services.Courses.Application.Commands.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Convey.CQRS.Commands;
    using Core.Entities;
    using Core.Repositories;

    public class AddCourseHandler : ICommandHandler<AddCourse>
    {
        private readonly ICourseRepository _repository;

        public AddCourseHandler(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddCourse command)
        {
            var course = new Course(command.CourseId, command.Title, command.Description, command.Tags,
                new List<Guid>());
            await _repository.AddAsync(course);
        }
    }
}