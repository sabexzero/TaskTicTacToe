using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Entities.Abstract;
using TicTacToeApi.Entities.Concrete.TicTacToe;

public class GamesDbContext : DbContext
{
	public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options)
	{

	}

	public DbSet<TicTacToePlayer> Players { get; set; }
	public DbSet<BoardTicTacToe> TTTes { get; set; }
}