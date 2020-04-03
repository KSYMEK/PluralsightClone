using System;
using System.Collections.Generic;

namespace Pluralsight.Services.Identity.Application {
	public interface IIdentityContext {
		Guid Guid { get; set; }
		string Role { get; }
		bool IsAuthenticated { get; }
		bool IsAdmin { get; }
		IDictionary<string, string> Claims { get; }
	}
}