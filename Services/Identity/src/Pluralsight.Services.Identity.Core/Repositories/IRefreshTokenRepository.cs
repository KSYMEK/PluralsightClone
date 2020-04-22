namespace Pluralsight.Services.Identity.Core.Repositories
{
    using System.Threading.Tasks;
    using Entities;

    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}