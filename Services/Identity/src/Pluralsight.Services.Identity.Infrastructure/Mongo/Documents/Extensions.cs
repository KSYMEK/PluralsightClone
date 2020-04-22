namespace Pluralsight.Services.Identity.Infrastructure.Mongo.Documents
{
    using System.Linq;
    using Application.DTO;
    using Core.Entities;

    internal static class Extensions
    {
        public static User AsEntity(this UserDocument document)
        {
            return new User(document.Id, document.Email,
                document.Password, document.Role, document.CreatedAt, document.Permissions);
        }

        public static UserDocument AsDocument(this User entity)
        {
            return new UserDocument
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                Email = entity.Email,
                Password = entity.Password,
                Permissions = entity.Permissions ?? Enumerable.Empty<string>(),
                Role = entity.Role
            };
        }

        public static UserDto AsDto(this UserDocument document)
        {
            return new UserDto
            {
                Id = document.Id,
                CreatedAt = document.CreatedAt,
                Email = document.Email,
                Permissions = document.Permissions ?? Enumerable.Empty<string>(),
                Role = document.Role
            };
        }

        public static RefreshToken AsEntity(this RefreshTokenDocument document)
        {
            return new RefreshToken(document.Id, document.UserId, document.Token, document.CreatedAt,
                document.RevokedAt);
        }

        public static RefreshTokenDocument AsDocument(this RefreshToken entity)
        {
            return new RefreshTokenDocument
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Token = entity.Token,
                CreatedAt = entity.CreatedAt,
                RevokedAt = entity.RevokedAt
            };
        }
    }
}