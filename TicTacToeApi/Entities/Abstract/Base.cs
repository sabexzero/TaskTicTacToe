namespace TicTacToeApi.Entities.Abstract;
public abstract class Base
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
}