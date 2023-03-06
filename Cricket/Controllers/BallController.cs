using Cricket.Data;
using Cricket.Models;
using Cricket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cricket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallController : ControllerBase
    {
        private readonly IBallService ballService;
        private readonly CricketDatabase _db;

        public BallController(IBallService ballService, CricketDatabase db)
        {
            this.ballService = ballService;
            this._db = db;
        }
        [HttpPost]
        public IActionResult PostMatch(AddBall ball)
        {
            var response = ballService.AddBall(ball);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetBalll(Guid id, int BallNo, Guid Bowler, int over, Guid StrikeBatsman, string? status, Guid matchId, Guid BattingTeamId, Guid FieldingTeamId)
        {
            var response = ballService.GetBall(id, BallNo,Bowler,over,StrikeBatsman,status,matchId,BattingTeamId,FieldingTeamId);
            return Ok(response);
        }
    }
}

