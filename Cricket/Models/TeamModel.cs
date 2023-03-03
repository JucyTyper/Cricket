using System.ComponentModel.DataAnnotations;

namespace Cricket.Models
{
    public class TeamModel
    {
        [Key]
        public Guid TeamId { get; set; } = Guid.NewGuid();
        public string TeamName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
