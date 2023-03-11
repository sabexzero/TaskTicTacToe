using TicTacToeApi.Entities.Concrete.TicTacToe;
using TicTacToeApi.Data.Repositories.Abstract;
using TicTacToeApi.Data.Repositories.Concrete;
using TicTacToeApi.Services.Abstract;
using TicTacToeApi.Entities.Abstract;

namespace TicTacToeApi.Services.Concrete;
public class TicTacToeService : IGameService
{
    private readonly IBaseRepository<BoardTicTacToe> _repository;
    public TicTacToeService(IBaseRepository<BoardTicTacToe> repos)
    {
        _repository= repos;
    }
    public async Task CreateGame(BoardTicTacToe entity)
    {
        await _repository.Create(entity);
    }
    public async Task<bool> UpdateGame(BoardTicTacToe entity)
    {
        return await _repository.Update(entity);
    }
    public async Task<bool> DeleteGame(Guid id)
    {
        return await _repository.Delete(id);
    }

    public async Task<IEnumerable<BoardTicTacToe>> GetAllGames()
    {
        return await _repository.GetAll();
    }

    public async Task<BoardTicTacToe> GetGame(Guid id)
    {
        return await _repository.Get(id);
    }
    public async Task SaveChanges()
    {
        await _repository.Save();
    }
}