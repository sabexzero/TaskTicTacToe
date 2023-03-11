using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Data.Repositories.Abstract;
using TicTacToeApi.Entities.Abstract;
using TicTacToeApi.Entities.Concrete.TicTacToe;

#pragma warning disable CS8603 // Possible null reference return.
namespace TicTacToeApi.Data.Repositories.Concrete;
public class TicTacToeRepository : IBaseRepository<BoardTicTacToe>
{
    private readonly GamesDbContext _context;
    public TicTacToeRepository(GamesDbContext gameContext)
    {
        _context = gameContext;
    }

    public async Task Create(BoardTicTacToe entity)
    {
        await _context.Set<BoardTicTacToe>().AddAsync(entity);
    }

    public async Task<bool> Delete(Guid id)
    {
        var deleted = await _context.Set<BoardTicTacToe>().FirstOrDefaultAsync(s => s.Id == id);
        if (deleted != null)
        {
            _context.Set<BoardTicTacToe>().Remove(deleted);
            return true;
        }
        return false;
    }

    public async Task<BoardTicTacToe> Get(Guid id)
    {
        return await _context.Set<BoardTicTacToe>().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<bool> Update(BoardTicTacToe entity)
    {
        _context.Update(entity);
        await Save();
        return true;
    }

    public async Task<IEnumerable<BoardTicTacToe>> GetAll()
    {
        return await _context.TTTes.ToListAsync();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}