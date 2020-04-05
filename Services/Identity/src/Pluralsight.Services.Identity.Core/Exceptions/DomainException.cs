namespace Pluralsight.Services.Identity.Core.Exceptions {
    using System;

    public abstract class DomainException : Exception {
        protected DomainException(string message) : base(message) {
        }

        public abstract string Code { get; }
    }
}