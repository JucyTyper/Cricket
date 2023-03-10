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
        public IActionResult Get(Guid Id, string? FirstName, string? LastName, int age,string? playerType,Guid TeamId, bool status )
        {
            var response = playerServices.PlayerGet(Id, FirstName,LastName, age, playerType, TeamId,status);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post(AddPlayer player)
        {
            var response = playerServices.PlayerPost(player);
            return Ok(response);
        }
        [HttpDelete]
        public IActionResult DeletePlayer(Guid Id)
        {
            var response = playerServices.PlayerDelete(Id);
            return Ok(response);
        }

    }
}
