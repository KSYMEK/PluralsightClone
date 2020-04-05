namespace Pluralsight.Services.Identity.Application.Exceptions {
    using System;

    public class UserNotFoundException : AppException {
        public UserNotFoundException(Guid userId) : base($"User with ID: {userId} was not found.") {
            UserId = userId;
        }

        public override string Code => "user_not_found";
        public Guid UserId { get; }
    }
}