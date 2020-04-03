using System;

namespace Pluralsight.Services.Identity.Application.Exceptions {
	public class UserNotFoundException : AppException {
		public UserNotFoundException(Guid userId) : base($"User with ID: {userId} was not found.") {
			UserId = userId;
		}

		public override string Code { get; }
		public Guid UserId { get; }
	}
}