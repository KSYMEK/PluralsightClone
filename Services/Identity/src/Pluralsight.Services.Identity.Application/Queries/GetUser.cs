using System;
using Convey.CQRS.Queries;
using Pluralsight.Services.Identity.Application.DTO;

namespace Pluralsight.Services.Identity.Application.Queries {
	public class GetUser : IQuery<UserDto> {
		public Guid UserId { get; set; }
	}
}