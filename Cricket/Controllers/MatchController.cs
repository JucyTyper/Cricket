using Cricket.Data;
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
        public IActionResult Index()
        {
            var model = MatchService.selectPlayer();
            return Ok(model);
        }
    }
}
