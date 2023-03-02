using Cricket.Models;

namespace Cricket.Services
{
    public interface IPlayerServices
    {
        public object PlayerGet(Guid Id, string Name, int age, string playerType, string Team,int Matches);
        public object PlayerPost(AddPlayer player);
    }
}
