using Convey.CQRS.Events;

namespace Pluralsight.Services.Identity.Application.Events.Rejected {
	[Contract]
	public class SignedUpRejected : IRejectedEvent {
		public string Reason { get; }
		public string Code { get; }
		public string Email { get; }

		public SignedUpRejected(string email, string reason, string code) {
			Email = email;
			Reason = reason;
			Code = code;
		}
	}
}