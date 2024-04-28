using Demo.Models;
using Demo.ViewModel;

namespace Demo.Repos
{
    public interface IStoreItemRepo
    {
        public StoreItemViewModel show();
        public int GetQuantity(int StoreId, int ItemId);
        public StoreItemViewModel AddQuantity(StoreItemViewModel viewmodel);

    }
}
