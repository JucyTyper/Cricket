using Azure;
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
            try
            {
                var match = new Match
                {
                    MatchId = Guid.NewGuid(),
                    Date= _match.Date,
                    TeamA= _match.TeamA,
                    TeamB= _match.TeamB,
                    NoOfOvers= _match.NoOfOvers,
                    TossWon= _match.TossWon,
                };
                _db.matches.Add(match);
                response.StatusCode = 200;
                response.Message = "Match created";
                response.Data = match;
                return response;
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
                response.StatusCode= 500;
                return response;
            }
            
        }
        public object GetMatch(Guid id, DateTime date, Guid TeamA, Guid TeamB, int overs) 
        {
            try
            {
                var Match = _db.matches.Where(x => (x.MatchId == id||id == Guid.Empty)&&(x.Date==date||date == DateTime.MinValue)&&(x.TeamA == TeamA || x.TeamA == TeamB || TeamA == Guid.Empty) && (x.TeamB == TeamA || x.TeamB == TeamB || TeamB == Guid.Empty)&&(x.NoOfOvers == overs || overs == 0)).Select(x => new {x.Date,x.TossWon,x.MatchId,x.NoOfOvers,x.TeamA,x.TeamB });
                if (Match.Count() == 0)
                {
                    response.StatusCode = 404;
                    response.Message = "Match Not Found";
                    return response;
                }
                response.Data = Match;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
