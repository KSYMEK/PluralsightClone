namespace Pluralsight.Services.Courses.Application.Commands.Handlers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Convey.CQRS.Commands;
    using Core.Entities;
    using Core.Repositories;
    using Services;

    public class AddCourseHandler : ICommandHandler<AddCourse>
    {
        private readonly ICourseRepository _repository;
        private readonly IMessageBroker _messageBroker;

        public AddCourseHandler(ICourseRepository repository, IMessageBroker messageBroker)
        {
            _repository = repository;
            _messageBroker = messageBroker;
        }
        
        public async Task HandleAsync(AddCourse command)
        {
            var course = new Course(command.CourseId, command.Title, command.Description, command.Tags, new List<CourseModule>());
            await _repository.AddAsync(course);
        }
    }
}