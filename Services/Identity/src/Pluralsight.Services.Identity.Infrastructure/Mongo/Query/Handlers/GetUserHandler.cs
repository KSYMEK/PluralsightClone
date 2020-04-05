namespace Pluralsight.Services.Identity.Infrastructure.Mongo.Query.Handlers {
    using System;
    using System.Threading.Tasks;
    using Application.DTO;
    using Application.Queries;
    using Convey.CQRS.Queries;
    using Convey.Persistence.MongoDB;
    using Documents;

    internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto> {
        private readonly IMongoRepository<UserDocument, Guid> _userRepository;

        public GetUserHandler(IMongoRepository<UserDocument, Guid> userRepository) {
            _userRepository = userRepository;
        }

        public async Task<UserDto> HandleAsync(GetUser query) {
            var user = await _userRepository.GetAsync(query.UserId);
            return user?.AsDto();
        }
    }
}