namespace TicTacToeApi.Data.Repositories.Abstract
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Delete(Guid id);
        Task<bool> Update(T entity);
        Task Save();
    }
}
