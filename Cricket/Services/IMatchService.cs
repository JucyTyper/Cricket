using Cricket.Models;

namespace Cricket.Services
{
    public interface IMatchService 
    {
        public object CreateMatch(AddMatch _match);
    }
}
