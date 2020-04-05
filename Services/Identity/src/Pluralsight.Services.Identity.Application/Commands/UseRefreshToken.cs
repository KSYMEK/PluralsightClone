namespace Pluralsight.Services.Identity.Application.Commands {
    using Convey.CQRS.Commands;

    public class UseRefreshToken : ICommand {
        public UseRefreshToken(string refreshToken) {
            RefreshToken = refreshToken;
        }

        public string RefreshToken { get; }
    }
}