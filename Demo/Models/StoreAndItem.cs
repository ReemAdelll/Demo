using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class StoreAndItem
    {
        
        public int Id { get; set; }
        [ForeignKey("Store")]
        public int Store_Id { get; set; }
        [ForeignKey("Item")]
        public int Item_Id { get; set; }

        public int Quantity { get; set; }
        public Store Store { get; set; }
        public Item Item { get; set; }
    }
}
