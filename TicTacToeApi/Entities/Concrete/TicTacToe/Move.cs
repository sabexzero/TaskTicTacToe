using TicTacToeApi.Entities.Abstract;

namespace TicTacToeApi.Entities.Concrete.TicTacToe
{
    public class Move : Base
    {
        public Move() 
        {
            Id = Guid.NewGuid();
        }
        public Guid PlayerId { get; set; }
        public int Cell { get; set; }
    }
}
