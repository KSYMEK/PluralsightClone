namespace Pluralsight.Services.Identity.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;

    public class User : AggregateRoot
    {
        public User(Guid id, string email, string password, string role, DateTime createdAt,
            IEnumerable<string> permissions = null)
        {
            if (string.IsNullOrEmpty(email))
                throw new InvalidEmailException(email);
            if (string.IsNullOrEmpty(password))
                throw new InvalidPasswordException(password);
            if (!Entities.Role.IsValid(role))
                throw new InvalidRoleException(role);

            Id = id;
            Email = email;
            Password = password;
            Role = role;
            CreatedAt = createdAt;
            Permissions = permissions ?? Enumerable.Empty<string>();
        }

        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public IEnumerable<string> Permissions { get; }
        public DateTime CreatedAt { get; }
    }
}