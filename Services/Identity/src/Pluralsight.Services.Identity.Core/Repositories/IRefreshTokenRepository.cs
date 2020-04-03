using System.Threading.Tasks;
using Pluralsight.Services.Identity.Core.Entities;

namespace Pluralsight.Services.Identity.Core.Repositories {
	public interface IRefreshTokenRepository {
		Task<RefreshToken> GetAsync(string token);
		Task AddAsync(RefreshToken token);
		Task UpdateAsync(RefreshToken token);
	}
}