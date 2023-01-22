using System.Collections.Generic;

namespace Aflevering1.MVC.Models
{
    public class ItemAndPlacementData
    {
        public Item Item { get; set; }
        public List<Placement> Placements { get; set; }
        public List<Unit> Units { get; set; }
    }
}
