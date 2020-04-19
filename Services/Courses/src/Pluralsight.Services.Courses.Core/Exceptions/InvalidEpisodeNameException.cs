namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidEpisodeNameException : DomainException
    {
        public InvalidEpisodeNameException() : base("Invalid episode name.")
        {
        }

        public override string Code => "invalid_episode_name";
    }
}