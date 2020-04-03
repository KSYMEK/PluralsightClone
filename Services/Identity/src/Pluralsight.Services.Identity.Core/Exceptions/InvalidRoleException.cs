namespace Pluralsight.Services.Identity.Core.Exceptions {
	public class InvalidRoleException : DomainException {
		public InvalidRoleException(string role) : base($"Invalid role: {role}.") {
		}

		public override string Code => "invalid_role";
	}
}