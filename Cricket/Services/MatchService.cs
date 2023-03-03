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
                    TeamName = _match.TeamB,
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
                        TeamId= teamA.TeamId,
                    };
                    _db.playerMapModels.Add(PlayerMap);
                }
                foreach (string s in _match.TeamBPlayers)
                {
                    var PlayerMap = new PlayerMapModel
                    {
                        PlayerId = new Guid(s),
                        MatchId = match.MatchId,
                        TeamId = teamB.TeamId,
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
        public object GetMatch(Guid id, string date, string TeamA, string TeamB)
        {
            GetMatchModel _match = new GetMatchModel();
            List <GetMatchModel> MatchList = new List<GetMatchModel>();
            try
            {
                var match = from x in _db.matches
                              where (x.TeamA == TeamA || TeamA == null) && (x.MatchId == id || id == Guid.Empty) && (x.TeamB == TeamB || TeamB == null) && (x.Date == date || date == null)
                              select new {x.MatchId,x.Date,x.TeamA,x.TeamB};
                match.AsQueryable();
                if (match.Count() == 0)
                {
                    response.StatusCode = 404;
                    response.Message = "Match Not Found";
                    return response;
                }
                foreach (var x in match) 
                {
                    _match.MatchId= x.MatchId;
                    _match.Date = x.Date;
                    _match.TeamA = x.TeamA;
                    _match.TeamB = x.TeamB;
                    var TeamAID = from t in _db.teams
                                  where (t.TeamName == _match.TeamA) && (t.MatchID == _match.MatchId)
                                  select t.TeamId;
                    var TeamBID = from t in _db.teams
                                  where (t.TeamName == _match.TeamA) && (t.MatchID == _match.MatchId)
                                  select t.TeamId;
                    var TeamAPlayerIDList = from p in _db.playerMapModels
                                              where p.TeamId == TeamAID.First()
                                              select p.PlayerId;
                    var TeamBplayerIDList = from p in _db.playerMapModels
                                            where p.TeamId == TeamBID.First()
                                            select p.PlayerId;
                    List<string> TeamAplayerList = new List<string>();
                    foreach (var s in TeamAPlayerIDList)
                    {
                        var playername = from p in _db.players
                                         where p.Id == s
                                         select p.FirstName.ToString();
                        TeamAplayerList.Add(playername.First());
                    }
                    _match.TeamAPlayers = TeamAplayerList;

                    List<string> TeamBplayerList = null;
                    foreach (var s in TeamBplayerIDList)
                    {
                        var playername = from p in _db.players
                                         where p.Id == s
                                         select p.FirstName.ToString();
                        TeamBplayerList.Add(playername.First());
                    }
                    _match.TeamBPlayers = TeamBplayerList;
                    MatchList.Add(_match);
                }
                response.Data = MatchList;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
