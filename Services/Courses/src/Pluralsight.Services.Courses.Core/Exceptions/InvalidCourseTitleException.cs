namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidCourseTitleException : DomainException
    {
        public InvalidCourseTitleException() : base($"Invalid course title.")
        {
        }

        public override string Code => "invalid_course_title";
    }
}