using Demo.Models;
using Demo.ViewModel;

namespace Demo.Repos
{
    public class StoreItemRepo : IStoreItemRepo
    {
        private readonly Demo_dbcontext _context;

        public StoreItemRepo(Demo_dbcontext context)
        {
            _context = context;
        }
        public StoreItemViewModel AddQuantity(StoreItemViewModel viewmodel)
        {
            StoreAndItem storeAndItem = new StoreAndItem
            {
                Store_Id = viewmodel.Store_Id,
                Item_Id = viewmodel.Item_Id,
                Quantity = viewmodel.Quantity
            };
            _context.StoresAndItems.Add(storeAndItem);
            _context.SaveChanges();
            var store = _context.Stores.ToList();
            var item = _context.Items.ToList();

            StoreItemViewModel model = new StoreItemViewModel
            {
                Stores = store,
                Items = item,
                Quantity = viewmodel.Quantity
            };
            return model;
        }

        public int GetQuantity(int StoreId, int ItemId)
        {
            var Total_Quantity = _context.StoresAndItems.Where
                (a => a.Store_Id == StoreId && a.Item_Id == ItemId).Sum(a => a.Quantity);
            return Total_Quantity;
        }

        public StoreItemViewModel show()
        {
            var store = _context.Stores.ToList();
            var item = _context.Items.ToList();

            StoreItemViewModel model = new StoreItemViewModel { Stores = store, Items = item };
            return model;
        }
    }
}
