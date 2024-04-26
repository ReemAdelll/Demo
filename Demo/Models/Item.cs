using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public String Item_Name { get; set; }
    }
}
