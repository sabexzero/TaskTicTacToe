using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.Services.Concrete;
using TicTacToeApi.Services.Abstract;
using TicTacToeApi.Entities.Concrete.TicTacToe;
using TicTacToe;
using TicTacToeApi.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace TicTacToeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicTacToeController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IPlayerService _playerService;
        public TicTacToeController(IGameService gameService, IPlayerService playerService)
        {
            _gameService = gameService;
            _playerService = playerService;
        }

        [HttpGet("AllGames")]
        public async Task<IEnumerable<BoardTicTacToe>> Index()
        {
            return await _gameService.GetAllGames();
        }
        [HttpGet("OneGame")]
        // Get concrete Game by id
        public async Task<ActionResult<BoardTicTacToe>> Details(Guid id)
        {
            return await _gameService.GetGame(id);
        }
        //Create Game
        [HttpPost("CreateGame")]
        public async Task<ActionResult<BoardTicTacToe>> Create()
        {
            BoardTicTacToe model = new ();
            await _gameService.CreateGame(model);
            await _gameService.SaveChanges();
            return Ok(model);
        }
        //Make move
        [HttpPost("MakeMove")]
        public async Task<ActionResult> MakeMove(Guid gameId, Move move)
        {
            var search = await _gameService.GetGame(gameId);
            if (search == null)
            {
                return BadRequest("Game not found");
            }
            if (search.GameFinished)
            {
                return BadRequest("This game is already finished");
            }
            if (search != null)
            {
                if (search.CurrentTurn == 'X')
                {
                    if ((search.Xid == Guid.Empty || search.Xid == move.PlayerId) && search.Oid != move.PlayerId)
                    {
                        search.Board = search.Board.Replace(search.Board[move.Cell], 'X');
                        await _gameService.UpdateGame(search);
                        search.Xid = move.PlayerId;
                        search.CurrentTurn = 'O';
                    }
                }
                if (search.CurrentTurn == 'O')
                {
                    if ((search.Oid == Guid.Empty || search.Oid == move.PlayerId) && search.Xid != move.PlayerId)
                    {
                        search.Board = search.Board.Replace(search.Board[move.Cell], 'O');
                        await _gameService.UpdateGame(search);
                        search.Oid = move.PlayerId;
                        search.CurrentTurn = 'X';
                    }
                }
                search.WinCheck();
                await _gameService.SaveChanges();
                if (search.GameFinished == true)
                {
                    var searchPlayerX = await _playerService.GetPlayer(search.Xid);
                    var searchPlayerO = await _playerService.GetPlayer(search.Oid);
                    if (search.Winner == "X")
                    {
                        searchPlayerX.Wins += 1;
                        searchPlayerO.Loses += 1;
                    }
                    if (search.Winner == "O")
                    {
                        searchPlayerO.Wins += 1;
                        searchPlayerX.Loses += 1;
                    }
                    if (search.Winner == "O")
                    {
                        searchPlayerX.Draws += 1;
                        searchPlayerO.Draws += 1;
                    }
                    await _playerService.UpdatePlayer(searchPlayerO);
                    await _playerService.UpdatePlayer(searchPlayerX);
                    await _playerService.SaveChanges();
                }
            }
            return Ok(search);

        }
        //Delete Game
        [HttpDelete("DeleteGame")]
        public async Task Delete(Guid id)
        {
            await _gameService.DeleteGame(id);
            await _gameService.SaveChanges();
        }

    }
}
