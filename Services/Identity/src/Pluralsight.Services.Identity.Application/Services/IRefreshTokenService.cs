using System;
using System.Threading.Tasks;
using Pluralsight.Services.Identity.Application.DTO;

namespace Pluralsight.Services.Identity.Application.Services {
	public interface IRefreshTokenService {
		Task<string> CreateAsync(Guid userId);
		Task RevokeAsync(string refreshToken);
		Task<AuthDto> UseAsync(string refreshToken);
	}
}