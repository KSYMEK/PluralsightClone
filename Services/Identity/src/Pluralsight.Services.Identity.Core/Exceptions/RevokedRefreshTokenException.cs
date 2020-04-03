namespace Pluralsight.Services.Identity.Core.Exceptions {
	public class RevokedRefreshTokenException : DomainException {
		public RevokedRefreshTokenException() : base("Revoked refresh token.") {
		}

		public override string Code => "revoked_refresh_token";
	}
}