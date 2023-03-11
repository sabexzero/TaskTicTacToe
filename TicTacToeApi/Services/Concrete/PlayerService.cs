using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Entities.Concrete;
using TicTacToeApi.Data.Repositories.Concrete;
using TicTacToeApi.Services.Abstract;
using TicTacToeApi.Data.Repositories.Abstract;

namespace TicTacToeApi.Services.Concrete
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository<TicTacToePlayer> _repository;
        public PlayerService(IPlayerRepository<TicTacToePlayer> repos)
        {
            _repository = repos;
        }
        public async Task CreatePlayer(TicTacToePlayer entity)
        {
            await _repository.Create(entity);
        }
        public async Task<bool> UpdatePlayer(TicTacToePlayer entity)
        {
            return await _repository.Update(entity);
        }
        public async Task<bool> DeletePlayer(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<TicTacToePlayer>> GetAllPlayers()
        {
            return await _repository.GetAll();
        }

        public async Task<TicTacToePlayer> GetPlayer(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<TicTacToePlayer> GetUserByName(string username)
        {
            return await _repository.GetByName(username);
        }

        public async Task<int[]> GetUserStats(Guid id)
        {
            return await _repository.GetStats(id);
        }

        public async Task<int[]> GetUserStatsByName(string username)
        {
            return await _repository.GetStatsByName(username);
        }
        public async Task SaveChanges()
        {
            await _repository.Save();
        }
    }
}
