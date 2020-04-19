namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidModuleNameException : DomainException
    {
        public InvalidModuleNameException() : base("Invalid course module name.")
        {
        }

        public override string Code => "invalid_module_name";
    }
}