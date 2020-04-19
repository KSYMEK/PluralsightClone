namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidEpisodeOrderException : DomainException
    {
        public InvalidEpisodeOrderException(string episodeName) : base($"Invalid episode order value for episode: {episodeName}")
        {
        }

        public override string Code => "invalid_episode_order_value";
    }
}