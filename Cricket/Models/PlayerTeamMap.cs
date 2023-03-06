using System.ComponentModel.DataAnnotations;

namespace Cricket.Models
{
    public class PlayerTeamMap
    {
        [Key]
        public Guid TeamMapId { get; set; } = Guid.NewGuid();
        public Guid PlayerID { get; set; }
        public Guid TeamID { get; set; }
        public bool IsRemoved { get; set; } = false;
    }
}
