using System;

namespace Pluralsight.Services.Identity.Core.Exceptions {
	public class InvalidPasswordException : DomainException {
		public InvalidPasswordException(string password) : base($"Invalid user password: {password}.") {
			
		}

		public override string Code => "invalid_password";
	}
}