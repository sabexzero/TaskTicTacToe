using TicTacToeApi.Data.Repositories.Concrete;
using TicTacToeApi.Entities.Abstract;
using TicTacToeApi.Entities.Concrete.TicTacToe;

namespace TicTacToeApi.Services.Abstract;
public interface IGameService
{
    Task CreateGame(BoardTicTacToe entity);

    Task<bool> DeleteGame(Guid id);

    Task<IEnumerable<BoardTicTacToe>> GetAllGames();

    Task<BoardTicTacToe> GetGame(Guid id);
    Task<bool> UpdateGame(BoardTicTacToe entity);

    Task SaveChanges();
}