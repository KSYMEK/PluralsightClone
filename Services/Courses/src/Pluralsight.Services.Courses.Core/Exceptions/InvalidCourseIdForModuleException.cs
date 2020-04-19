namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidCourseIdForModuleException : DomainException
    {
        public InvalidCourseIdForModuleException(string moduleName) : base($"Invalid course ID for course module: {moduleName}")
        {
        }

        public override string Code => "invalid_course_id_for_module";
    }
}