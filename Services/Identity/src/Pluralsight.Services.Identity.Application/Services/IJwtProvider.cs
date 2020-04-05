namespace Pluralsight.Services.Identity.Application.Services {
    using System;
    using System.Collections.Generic;
    using DTO;

    public interface IJwtProvider {
        AuthDto Create(Guid userId, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}