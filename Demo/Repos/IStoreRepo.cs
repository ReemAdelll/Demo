using Demo.Models;

namespace Demo.Repos
{
    public interface IStoreRepo
    {
        public List<Store> show();
        public Store GetById(int id);
        void Add(Store store);
        void Update(Store store);
        void Delete(int id);
    }
}
