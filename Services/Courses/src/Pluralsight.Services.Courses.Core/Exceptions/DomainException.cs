namespace Pluralsight.Services.Courses.Core.Exceptions
{
    using System;

    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
        }

        public abstract string Code { get; }
    }
}