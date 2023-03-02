using Cricket.Data;
using Cricket.Models;
using Cricket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cricket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerServices playerServices;
        private readonly CricketDatabase _db;

        public PlayerController(IPlayerServices playerServices, CricketDatabase db)
        {
            this.playerServices = playerServices;
            this._db = db;
        }

        [HttpGet]
        [Route("Player")]
        public IActionResult Get(Guid Id, string? Name, int age,string? playerType,string? Team, int Matches )
        {
            var response = playerServices.PlayerGet(Id, Name, age, playerType, Team, Matches);
            return Ok(response);
        }
        [HttpPost]
        [Route("Player")]
        public IActionResult Post(AddPlayer player)
        {
            var response = playerServices.PlayerPost(player);
            return Ok(response);
        }
    }
}
