namespace Pluralsight.Services.Identity.Application.Commands {
    using Convey.CQRS.Commands;

    public class RevokeAccessToken : ICommand {
        public RevokeAccessToken(string accessToken) {
            AccessToken = accessToken;
        }

        public string AccessToken { get; }
    }
}