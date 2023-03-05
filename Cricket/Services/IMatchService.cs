using Cricket.Models;

namespace Cricket.Services
{
    public interface IMatchService 
    {
        public object CreateMatch(AddMatch _match);
        public object GetMatch(Guid id,DateTime date,Guid TeamA,Guid TeamB,int overs);
    }
}
