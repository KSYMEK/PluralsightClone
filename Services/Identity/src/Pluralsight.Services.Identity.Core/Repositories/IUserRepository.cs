namespace Pluralsight.Services.Identity.Core.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}