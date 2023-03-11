using TicTacToeApi.Entities.Concrete;
using TicTacToeApi.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.
namespace TicTacToeApi.Data.Repositories.Concrete;
public class PlayerReposotory : IPlayerRepository<TicTacToePlayer>
{
    private readonly GamesDbContext _context;
    public PlayerReposotory(GamesDbContext context)
    {
        _context = context;
    }
    public async Task Create(TicTacToePlayer entity)
    {
        await _context.Set<TicTacToePlayer>().AddAsync(entity);
    }

    public async Task<bool> Delete(Guid id)
    {
        var deleted = await _context.Set<TicTacToePlayer>().FirstOrDefaultAsync(s => s.Id == id);
            if (deleted != null)
            {
                _context.Set<TicTacToePlayer>().Remove(deleted);
                return true;
            }
        return false;
    }

    public async Task<bool> Update(TicTacToePlayer player)
    {
        _context.Update(player);
        await Save();
        return true;
    }

    public async Task<TicTacToePlayer> Get(Guid id)
    {
        return await _context.Set<TicTacToePlayer>().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<TicTacToePlayer>> GetAll()
    {
        return await _context.Set<TicTacToePlayer>().ToListAsync();
    }

    public async Task<TicTacToePlayer> GetByName(string username)
    {
        return await _context.Set<TicTacToePlayer>().FirstOrDefaultAsync(s => s.Username == username);
    }

    public async Task<int[]> GetStats(Guid id)
    {
        var search = await Get(id);
        int[] stats = new int[3]; // Wins, Loses, Draws
        stats[0] = search.Wins; stats[1] = search.Loses; stats[2] = search.Draws;
        return stats;
    }

    public async Task<int[]> GetStatsByName(string username)
    {
        var search = await GetByName(username);
        int[] stats = new int[3]; // Wins, Loses, Draws
        stats[0] = search.Wins; stats[1] = search.Loses; stats[2] = search.Draws;
        return stats;
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}