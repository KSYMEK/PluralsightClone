namespace Pluralsight.Services.Identity.Application.Commands {
    using System;
    using System.Collections.Generic;
    using Convey.CQRS.Commands;

    [Contract]
    public class SignUp : ICommand {
        public SignUp(Guid userId, string email, string password, string role, IEnumerable<string> permissions) {
            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;
            Email = email;
            Password = password;
            Role = role;
            Permissions = permissions;
        }

        public Guid UserId { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public IEnumerable<string> Permissions { get; }
    }
}