using System.Reflection;
using System.Security.Cryptography;
using TicTacToeApi.Entities.Abstract;

namespace TicTacToeApi.Entities.Concrete.TicTacToe
{
    public class BoardTicTacToe : Base
    {
        public BoardTicTacToe()
        {
            Id = Guid.NewGuid();
            Xid = Guid.Empty;
            Oid = Guid.Empty;
            CreatedDate = DateTime.UtcNow;
            CurrentTurn = 'X';
            GameFinished = false;
            Board = "012345678";
        }
        public Guid Xid { get; set; }
        public char CurrentTurn { get; set; }
        public Guid Oid { get; set; }
        public string Board { get; set; } 
        public string? Winner { get; set; }
        public bool GameFinished { get; set; }
        public void WinCheck()
        {
            bool check = false;
            int[][] wins = new int[][]
    {
                    new int[]{ 0, 1, 2 },
                    new int[]{ 3, 4, 5 },
                    new int[]{ 6, 7, 8 },
                    new int[]{ 0, 3, 6 },
                    new int[]{ 1, 4, 7 },
                    new int[]{ 2, 5, 8 },
                    new int[]{ 0, 4, 8 },
                    new int[]{ 2, 4, 6 }
    };

            foreach (var item in wins)
            {
                if (Board[item[0]] == 'X' && Board[item[1]] == 'X' && Board[item[2]] == 'X')
                {
                    Winner = "X";
                    check = true;
                    GameFinished = true;
                }
                if (Board[item[0]] == 'O' && Board[item[1]] == 'O' && Board[item[2]] == 'O')
                {
                    Winner = "O";
                    check = true;
                    GameFinished = true;
                }
            }
            int count = Board.Where(x => x == 'X').Count() + Board.Where(x => x == 'O').Count();
            if (count == 9 && check == false)
            {
                Winner = "T";
            }
        }
    }
}
