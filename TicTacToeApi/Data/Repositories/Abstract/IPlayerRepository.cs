namespace TicTacToeApi.Data.Repositories.Abstract
{
    public interface IPlayerRepository<T> : IBaseRepository<T> where T : class
    {
        Task<T> GetByName(string username);
        Task<int[]> GetStats(Guid id);
        Task<int[]> GetStatsByName(string username);
    }
}
