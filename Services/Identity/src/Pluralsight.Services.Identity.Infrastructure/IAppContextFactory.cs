using Pluralsight.Services.Identity.Application;

namespace Pluralsight.Services.Identity.Infrastructure {
	public interface IAppContextFactory {
		IAppContext Create();
	}
}