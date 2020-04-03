using System;
using System.Threading.Tasks;
using Pluralsight.Services.Identity.Core.Entities;

namespace Pluralsight.Services.Identity.Core.Repositories {
	public interface IUserRepository {
		Task<User> GetAsync(Guid id);
		Task<User> GetAsync(string email);
		Task AddAsync(User user);
	}
}