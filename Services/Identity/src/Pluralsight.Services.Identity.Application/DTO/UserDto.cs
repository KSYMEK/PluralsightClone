namespace Pluralsight.Services.Identity.Application.DTO {
    using System;
    using System.Collections.Generic;
    using Core.Entities;

    public class UserDto {
        public UserDto() {
        }

        public UserDto(User user) {
            Id = user.Id;
            Email = user.Email;
            Role = user.Role;
            CreatedAt = user.CreatedAt;
            Permissions = user.Permissions;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}