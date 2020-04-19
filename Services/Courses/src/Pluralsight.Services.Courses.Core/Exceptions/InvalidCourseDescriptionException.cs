namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidCourseDescriptionException : DomainException
    {
        public InvalidCourseDescriptionException() : base("Invalid course description.")
        {
        }

        public override string Code => "invalid_course_description";
    }
}