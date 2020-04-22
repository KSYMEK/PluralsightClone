namespace Pluralsight.Services.Identity.Application.Commands
{
    using Convey.CQRS.Commands;

    [Contract]
    public class RevokeRefreshToken : ICommand
    {
        public RevokeRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public string RefreshToken { get; }
    }
}