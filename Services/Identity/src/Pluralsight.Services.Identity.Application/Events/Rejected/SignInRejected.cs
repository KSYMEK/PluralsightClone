namespace Pluralsight.Services.Identity.Application.Events.Rejected
{
    using Convey.CQRS.Events;

    [Contract]
    public class SignInRejected : IRejectedEvent
    {
        public SignInRejected(string email, string reason, string code)
        {
            Reason = reason;
            Email = email;
            Code = code;
        }

        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
    }
}