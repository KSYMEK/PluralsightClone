namespace Pluralsight.Services.Identity.Core.Exceptions {
	public class EmptyRefreshTokenException : DomainException
	{
		public override string Code => "empty_refresh_token";
        
		public EmptyRefreshTokenException() : base("Empty refresh token.")
		{
		}
	}
}