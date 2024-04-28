using Demo.Models;

namespace Demo.Repos
{
    public interface IItemRepo
    {
        public List<Item> show();
        public Item GetById(int id);
        void Add (Item item);
        void Update(Item item);
        void Delete(int id);

    }
}
