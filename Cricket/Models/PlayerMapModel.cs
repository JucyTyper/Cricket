using System.ComponentModel.DataAnnotations;

namespace Cricket.Models
{
    public class PlayerMapModel
    {
        [Key]
        public Guid MapId { get; set; } = Guid.NewGuid();
        public Guid PlayerId { get; set; }
        public Guid MatchId { get; set; }
        public Guid TeamId { get; set; }
    }
}
