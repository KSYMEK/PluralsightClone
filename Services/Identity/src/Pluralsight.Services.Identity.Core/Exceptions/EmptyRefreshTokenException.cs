namespace Pluralsight.Services.Identity.Core.Exceptions {
    public class EmptyRefreshTokenException : DomainException {
        public EmptyRefreshTokenException() : base("Empty refresh token.") {
        }

        public override string Code => "empty_refresh_token";
    }
}