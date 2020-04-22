namespace Pluralsight.Services.Identity.Application.Events.Rejected
{
    using Convey.CQRS.Events;

    [Contract]
    public class SignedUpRejected : IRejectedEvent
    {
        public SignedUpRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }

        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
    }
}