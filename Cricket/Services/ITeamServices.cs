using Cricket.Models;

namespace Cricket.Services
{
    public interface ITeamServices
    {
        public object CreateTeam(AddTeam team);
        public object GetTeam(Guid id, string name);
        public object GetTeamplayers(Guid id);
    }
}
