using Microsoft.AspNetCore.Mvc;
using TicTacToeApi.Entities.Concrete;
using TicTacToeApi.Services.Concrete;
using TicTacToeApi.Services.Abstract;

namespace TicTacToeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("AllPlayers")]
        public async Task<IEnumerable<TicTacToePlayer>> Index()
        {
            return await _playerService.GetAllPlayers();
        }
        [HttpGet("OnePlayer")]
        public async Task<TicTacToePlayer> Details(Guid id)
        {
            return await _playerService.GetPlayer(id);
        }
        [HttpPost("CreatePlayer")]
        public async Task<ActionResult<TicTacToePlayer>> Create(string username)
        {
            TicTacToePlayer pl = new(username);
            await _playerService.CreatePlayer(pl);
            await _playerService.SaveChanges();
            return Ok(pl);
        }
        [HttpDelete("DeletePlayer")]
        public async Task Delete(Guid id)
        {
            await _playerService.DeletePlayer(id);
            await _playerService.SaveChanges();
        }
    }
}
