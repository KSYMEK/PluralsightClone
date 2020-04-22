namespace Pluralsight.Services.Identity.Application.Events
{
    using System;
    using Convey.CQRS.Events;

    [Contract]
    public class SignedUp : IEvent
    {
        public SignedUp(Guid userId, string email, string role)
        {
            UserId = userId;
            Email = email;
            Role = role;
        }

        public Guid UserId { get; }
        public string Email { get; }
        public string Role { get; }
    }
}