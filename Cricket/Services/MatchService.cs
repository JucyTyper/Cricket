using Cricket.Data;
using Cricket.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cricket.Services
{
    public class MatchService : IMatchService
    {
        private ResponseModel response = new ResponseModel();
        private readonly CricketDatabase _db;

        public MatchService(CricketDatabase _db)
        {
            this._db = _db;
        }
        public object CreateMatch(AddMatch _match)
        {
            var match = new Match();
            try
            {
                match.Date = _match.Date;
                match.TeamA = _match.TeamA;
                match.TeamB = _match.TeamB;
                var teamA = new Team
                {
                    TeamId = Guid.NewGuid(),
                    TeamName = _match.TeamA,
                    MatchID = match.MatchId
                };
                _db.teams.Add(teamA);
                var teamB = new Team
                {
                    TeamId = Guid.NewGuid(),
                    TeamName = _match.TeamA,
                    MatchID = match.MatchId
                };
                _db.teams.Add(teamB);
                _db.matches.Add(match);
                foreach(string s in _match.TeamAPlayers)
                {
                    var PlayerMap = new PlayerMapModel
                    {
                        PlayerId = new Guid(s),
                        MatchId= match.MatchId,
                        TeamId= teamA.MatchID,
                    };
                    _db.playerMapModels.Add(PlayerMap);
                }
                _db.SaveChanges();
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
                response.StatusCode= 500;
                return response;
            }
            response.StatusCode = 200;
            response.Message = "Match created";
            response.Data = match;
            return response;
        }

    }
}
