namespace Pluralsight.Services.Identity.Application.Exceptions
{
    using System;

    public abstract class AppException : Exception
    {
        protected AppException(string message) : base(message)
        {
        }

        public abstract string Code { get; }
    }
}