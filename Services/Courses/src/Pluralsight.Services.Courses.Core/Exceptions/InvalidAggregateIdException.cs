namespace Pluralsight.Services.Courses.Core.Exceptions
{
    public class InvalidAggregateIdException : DomainException
    {
        public InvalidAggregateIdException() : base("Invalid aggregate id.")
        {
        }

        public override string Code => "invalid_aggregate_id";
    }
}