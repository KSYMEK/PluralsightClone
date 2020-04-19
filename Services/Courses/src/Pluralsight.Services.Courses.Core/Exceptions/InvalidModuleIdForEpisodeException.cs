namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidModuleIdForEpisodeException : DomainException
    {
        public InvalidModuleIdForEpisodeException(string episodeName) : base($"Invalid module ID for episode called {episodeName}.")
        {
        }

        public override string Code => "invalid_module_id_for_episode";
    }
}