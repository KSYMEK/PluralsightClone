namespace Pluralsight.Services.Identity.Application.Queries {
    using System;
    using Convey.CQRS.Queries;
    using DTO;

    public class GetUser : IQuery<UserDto> {
        public Guid UserId { get; set; }
    }
}