namespace Pluralsight.Services.Identity.Application.Services
{
    using System;
    using System.Threading.Tasks;
    using Commands;
    using DTO;

    public interface IIdentityService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<AuthDto> SignInAsync(SignIn command);
        Task SignUpAsync(SignUp command);
    }
}