using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cricket.Models.ViewModel
{
    public class PlayerView
    {
        public Guid SelectedPlayerID { get; set; }
        public List<SelectListItem> PlayerSelectList { get; set; }
    }
}
