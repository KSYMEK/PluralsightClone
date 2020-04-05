namespace Pluralsight.Services.Identity.Application.Commands {
    using Convey.CQRS.Commands;

    [Contract]
    public class SignIn : ICommand {
        public SignIn(string email, string password) {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}