using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public String Store_Name { get; set; }
       
        public ICollection<StoreAndItem> StoreAndItem { get; set; } = new HashSet<StoreAndItem>();
    }
}
