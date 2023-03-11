using TicTacToeApi.Entities.Concrete;

namespace TicTacToeApi.Data.Repositories.Abstract
{
    public interface IGameRepository<T> : IBaseRepository<T> where T : class
    {
        /*Task<IEnumerable<T>> GetByUsernames(string username1,string username2);*/
    }
}
