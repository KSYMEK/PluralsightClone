namespace Pluralsight.Services.Identity.Infrastructure.Mongo.Documents {
    using System;
    using Convey.Types;

    internal sealed class RefreshTokenDocument : IIdentifiable<Guid> {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public Guid Id { get; set; }
    }
}