using System;
using System.Collections.Generic;
using System.Linq;
using Pluralsight.Services.Identity.Core.Exceptions;

namespace Pluralsight.Services.Identity.Core.Entities {
	public class User : AggregateRoot {
		public string Email { get; private set; }
		public string Password { get; private set; }
		public string Role { get; private set; }
		public IEnumerable<string> Permissions { get; private set; }
		public DateTime CreatedAt { get; private set; }

		public User(Guid id, string email, string password, string role, DateTime createdAt, IEnumerable<string> permissions = null) {
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
	}
}