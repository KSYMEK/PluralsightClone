namespace Pluralsight.Services.Identity.Application.Commands.Handlers {
    using System.Threading.Tasks;
    using Convey.CQRS.Commands;
    using Services;

    internal sealed class SignUpHandler : ICommandHandler<SignUp> {
        private readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService) {
            _identityService = identityService;
        }

        public Task HandleAsync(SignUp command) {
            return _identityService.SignUpAsync(command);
        }
    }
}