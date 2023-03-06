using Cricket.Models;
using Cricket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cricket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamServices teamServices;

        public TeamController(ITeamServices teamServices)
        {
            this.teamServices = teamServices;

        }
        [HttpPost]

        public IActionResult CreateTeam(AddTeam team)
        {
            var response = teamServices.CreateTeam(team);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetTeam(Guid id,string? name)
        {
            var response = teamServices.GetTeam(id,name);
            return Ok(response);
        }
        [HttpGet]
        [Route("TeamPlayer")]
        public IActionResult GetTeamPlayers(Guid TeamId)
        {
            var response = teamServices.GetTeamplayers(TeamId);
            return Ok(response);
        }
        [HttpPost]
        [Route("TeamPlayer")]
        public IActionResult AddTeamPlayer(AddTeamPlayer TeamPlayer)
        {
            var response = teamServices.AddTeamplayer(TeamPlayer);
            return Ok(response);
        }

    }
}
