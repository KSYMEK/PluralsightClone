using System;
using System.Threading.Tasks;
using Pluralsight.Services.Identity.Application.Commands;
using Pluralsight.Services.Identity.Application.DTO;

namespace Pluralsight.Services.Identity.Application.Services {
	public interface IIdentityService {
		Task<UserDto> GetAsync(Guid id);
		Task<AuthDto> SignInAsync(SignIn command);
		Task SignUpAsync(SignUp command);
	}
}