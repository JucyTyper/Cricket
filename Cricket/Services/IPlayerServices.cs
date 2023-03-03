using Cricket.Models;

namespace Cricket.Services
{
    public interface IPlayerServices
    {
        public object PlayerGet(Guid Id, string FirstName, string LastName, int age, string playerType, string Team);
        public object PlayerPost(AddPlayer player);
    }
}
