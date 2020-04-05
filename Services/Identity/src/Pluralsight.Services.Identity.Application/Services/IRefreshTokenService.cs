namespace Pluralsight.Services.Identity.Application.Services {
    using System;
    using System.Threading.Tasks;
    using DTO;

    public interface IRefreshTokenService {
        Task<string> CreateAsync(Guid userId);
        Task RevokeAsync(string refreshToken);
        Task<AuthDto> UseAsync(string refreshToken);
    }
}