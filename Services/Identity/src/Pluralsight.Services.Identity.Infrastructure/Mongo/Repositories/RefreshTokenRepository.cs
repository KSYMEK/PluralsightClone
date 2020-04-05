namespace Pluralsight.Services.Identity.Infrastructure.Mongo.Repositories {
    using System;
    using System.Threading.Tasks;
    using Convey.Persistence.MongoDB;
    using Core.Entities;
    using Core.Repositories;
    using Documents;

    internal sealed class RefreshTokenRepository : IRefreshTokenRepository {
        private readonly IMongoRepository<RefreshTokenDocument, Guid> _repository;

        public RefreshTokenRepository(IMongoRepository<RefreshTokenDocument, Guid> repository) {
            _repository = repository;
        }

        public async Task<RefreshToken> GetAsync(string token) {
            var refreshToken = await _repository.GetAsync(x => x.Token == token);
            return refreshToken?.AsEntity();
        }

        public Task AddAsync(RefreshToken token) {
            return _repository.AddAsync(token.AsDocument());
        }

        public Task UpdateAsync(RefreshToken token) {
            return _repository.UpdateAsync(token.AsDocument());
        }
    }
}