using Cricket.Data;
using Cricket.Models;

namespace Cricket.Services
{
    public class TeamServices :ITeamServices
    {
        private ResponseModel response = new ResponseModel();
        private readonly CricketDatabase _db;

        public TeamServices(CricketDatabase _db)
        {
            this._db = _db;
        }
        public object CreateTeam(AddTeam team)
        {
            try
            {
                var _team = new TeamModel();
                _team.TeamName = team.TeamName;
                foreach (var player in team.Players)
                {
                    var PlayerMap = new PlayerTeamMap();
                    PlayerMap.PlayerID = new Guid(player);
                    var PlayerData = _db.players.Where(x => x.Id == PlayerMap.PlayerID).Select(x=>x);
                    PlayerData.First().Team = _team.TeamId;
                    PlayerMap.TeamID = _team.TeamId;
                    _db.TeamPlayerMap.Add(PlayerMap);
                }
                _db.teams.Add(_team);
                _db.SaveChanges();
                response.Data = _team;
                response.Message = "team Successfully Added";
                return response;
            }
            catch(Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            }
        }
        public object DeleteTeam()
        {
            return response;
        }
        public object GetTeam(Guid id,string name)
        {
            try
            {
                var team = _db.teams.Where(x => (x.TeamId == id || id == Guid.Empty) && (x.TeamName == name || name == null)).Select(x => new { x.TeamId, x.TeamName, x.CreationDate });
                if (team.Count() == 0)
                {
                    response.StatusCode = 404;
                    response.Message = "Team Not Found";
                    return response;
                }
                response.Data = team;
                return response;
            }
            catch(Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            } 
        }
        public object GetTeamplayers(Guid id)
        {
            try
            {
                var teamPlayers = _db.TeamPlayerMap.Where(x => x.TeamID == id).Select(x => new { x.TeamID, x.PlayerID });
                if (teamPlayers.Count() == 0)
                {
                    response.StatusCode = 404;
                    response.Message = "Player Not Found";
                    return response;
                }
                response.Data = teamPlayers;
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
