namespace Pluralsight.Services.Identity.Application.DTO
{
    public class AuthDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
    }
}