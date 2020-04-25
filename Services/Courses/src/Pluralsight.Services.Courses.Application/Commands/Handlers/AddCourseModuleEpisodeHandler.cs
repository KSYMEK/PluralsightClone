namespace Pluralsight.Services.Courses.Application.Commands.Handlers
{
    using System.Threading.Tasks;
    using Convey.CQRS.Commands;
    using Core.Entities;
    using Core.Repositories;

    public class AddCourseModuleEpisodeHandler : ICommandHandler<AddCourseModuleEpisode>
    {
        private readonly ICourseEpisodeRepository _repository;

        public AddCourseModuleEpisodeHandler(ICourseEpisodeRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddCourseModuleEpisode command)
        {
            var episode = new CourseEpisode(command.EpisodeId, command.ModuleId, command.EpisodeName,
                command.EpisodeOrder, command.EpisodeVideoLink, command.Description);
            await _repository.AddAsync(episode, command.EpisodeId);
        }
    }
}