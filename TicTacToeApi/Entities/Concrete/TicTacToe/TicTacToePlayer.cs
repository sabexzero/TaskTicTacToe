using TicTacToeApi.Entities.Abstract;
public class TicTacToePlayer : Player
{
	public TicTacToePlayer(string username)
	{
		Id = Guid.NewGuid();
		Username = username;
		CreatedDate= DateTime.UtcNow;
	}
	public int Wins { get; set; }
    public int Loses { get; set; }
    public int Draws { get; set; }
}