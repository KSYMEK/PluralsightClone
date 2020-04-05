namespace Pluralsight.Services.Identity.Infrastructure.Auth {
    using System;
    using System.Collections.Generic;
    using Application.DTO;
    using Application.Services;
    using Convey.Auth;

    public class JwtProvider : IJwtProvider {
        private readonly IJwtHandler _jwtHandler;

        public JwtProvider(IJwtHandler jwtHandler) {
            _jwtHandler = jwtHandler;
        }

        public AuthDto Create(Guid userId, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null) {
            var jwt = _jwtHandler.CreateToken(userId.ToString("N"), role, audience, claims);

            return new AuthDto {
                Token = jwt.AccessToken,
                Role = jwt.Role,
                Expires = jwt.Expires
            };
        }
    }
}