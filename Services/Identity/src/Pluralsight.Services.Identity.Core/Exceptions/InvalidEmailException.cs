namespace Pluralsight.Services.Identity.Core.Exceptions {
    public class InvalidEmailException : DomainException {
        public InvalidEmailException(string email) : base($"Invalid user email: {email}.") {
        }

        public override string Code => "invalid_email";
    }
}