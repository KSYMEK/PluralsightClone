namespace Pluralsight.Services.Identity.Core.Entities {
	public static class Role {
		private const string Admin = "admin";
		private const string User = "user";

		public static bool IsValid(string role) {
			if (string.IsNullOrEmpty(role))
				return false;

			role = role.ToLowerInvariant();

			return role == Admin || role == User;
		}
	}
}