namespace Pluralsight.Services.Identity.Core.Exceptions {
    public class InvalidCredentialsException : DomainException {
        public InvalidCredentialsException(string email) : base("Invalid credentials.") {
            Email = email;
        }

        public override string Code => "invalid_credentials";
        public string Email { get; }
    }
}