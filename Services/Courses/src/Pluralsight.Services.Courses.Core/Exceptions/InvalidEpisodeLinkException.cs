namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidEpisodeLinkException : DomainException
    {
        public InvalidEpisodeLinkException(string episodeName) : base($"Invalid link for episode {episodeName}.")
        {
        }

        public override string Code => "invalid_episode_link";
    }
}