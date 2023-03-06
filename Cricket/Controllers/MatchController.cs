using Cricket.Data;
using Cricket.Models;
using Cricket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cricket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService MatchService;
        private readonly CricketDatabase _db;

        public MatchController(IMatchService MatchService, CricketDatabase db)
        {
            this.MatchService = MatchService;
            this._db = db;
        }
        [HttpPost]
        public IActionResult PostMatch(AddMatch match)
        {
            var response = MatchService.CreateMatch(match);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetMatch(Guid id,DateTime date,Guid TeamAId,Guid TeamBId, int overs)
        {
            var response = MatchService.GetMatch(id,date,TeamAId,TeamBId,overs);
            return Ok(response);
        }
    }
}
