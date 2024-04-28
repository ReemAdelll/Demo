using Demo.Models;

namespace Demo.Repos
{
    public class ItemRepo : IItemRepo
    {
        private readonly Demo_dbcontext _context;

        public ItemRepo(Demo_dbcontext context)
        {
            _context = context;
        }
        public List<Item> show()
        {
            return _context.Items.ToList();
        }
        public Item GetById(int id)
        {
            return _context.Items.FirstOrDefault(a => a.Id == id);
        }
        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        public void Update(Item item)
        {
            var Old_item = _context.Items.FirstOrDefault(a => a.Id == item.Id);
            Old_item.Item_Name = item.Item_Name;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var model = _context.Items.FirstOrDefault(a => a.Id == id);
            _context.Remove(model);
            _context.SaveChanges();
        }

    }
}
