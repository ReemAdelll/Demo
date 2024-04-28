using Demo.Models;

namespace Demo.Repos
{
    public class StoreRepo : IStoreRepo
    {
        private readonly Demo_dbcontext _context;

        public StoreRepo(Demo_dbcontext context)
        {
            _context = context;
        }
        public void Add(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Stores.FirstOrDefault(a => a.Id == id);
            _context.Remove(model);
            _context.SaveChanges();
        }

        public Store GetById(int id)
        {
            return _context.Stores.FirstOrDefault(a => a.Id == id);
        }

        public List<Store> show()
        {
            return _context.Stores.ToList();
        }


        public void Update(Store store)
        {
            var Old_item = _context.Stores.FirstOrDefault(a => a.Id == store.Id);
            Old_item.Store_Name = store.Store_Name;
            _context.SaveChanges();
        }
    }
}
