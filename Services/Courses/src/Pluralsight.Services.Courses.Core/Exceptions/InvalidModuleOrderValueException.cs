namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidModuleOrderValueException : DomainException
    {
        public InvalidModuleOrderValueException(string moduleName) : base($"Invalid module order value for module: {moduleName}")
        {
        }

        public override string Code => "invalid_module_order_value";
    }
}