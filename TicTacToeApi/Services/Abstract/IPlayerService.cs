using TicTacToeApi.Entities.Concrete;

namespace TicTacToeApi.Services.Abstract;
public interface IPlayerService
{
    Task CreatePlayer(TicTacToePlayer entity);
    Task<bool> DeletePlayer(Guid id);
    Task<IEnumerable<TicTacToePlayer>> GetAllPlayers();
    Task<TicTacToePlayer> GetPlayer(Guid id);
    Task<bool> UpdatePlayer (TicTacToePlayer entity);
    Task<TicTacToePlayer> GetUserByName(string username);
    Task<int[]> GetUserStats(Guid id);

    Task<int[]> GetUserStatsByName(string username);
    Task SaveChanges();
}