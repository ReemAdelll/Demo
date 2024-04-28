using Demo.Models;

namespace Demo.ViewModel
{
    public class StoreItemViewModel
    {
        public int Store_Id { get; set; }
        public List<Store> Stores { get; set; }
        public int Item_Id { get; set; }
        public List<Item> Items { get; set; }
        public int Quantity { get; set; }
    }
}
