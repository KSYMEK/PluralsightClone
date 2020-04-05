namespace Pluralsight.Services.Identity.Core.Exceptions {
    public class InvalidRefreshTokenException : DomainException {
        public InvalidRefreshTokenException() : base("Invalid refresh token.") {
        }

        public override string Code => "invalid_refresh_token";
    }
}