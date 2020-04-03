using Convey.CQRS.Events;

namespace Pluralsight.Services.Identity.Application.Events.Rejected {
	[Contract]
	public class SignInRejected : IRejectedEvent {
		public string Reason { get; }
		public string Code { get; }
		public string Email { get; }

		public SignInRejected(string email, string reason, string code) {
			Reason = reason;
			Email = email;
			Code = code;
		}
	}
}