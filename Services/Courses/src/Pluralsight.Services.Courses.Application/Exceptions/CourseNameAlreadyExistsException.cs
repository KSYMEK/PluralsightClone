namespace Pluralsight.Services.Courses.Application.Exceptions
{
    public class CourseNameAlreadyExistsException : AppException
    {
        public CourseNameAlreadyExistsException(string courseName) : base($"Course with name '{courseName}' already exists.")
        {
        }

        public override string Code => "course_name_already_exists";
    }
}