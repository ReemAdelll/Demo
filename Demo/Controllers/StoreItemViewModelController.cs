using Demo.Models;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StoreItemViewModelController : Controller
    {
        private readonly Demo_dbcontext _context;

        public StoreItemViewModelController(Demo_dbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var store = _context.Stores.ToList();
            var item = _context.Items.ToList();

            StoreItemViewModel model = new StoreItemViewModel { Stores = store, Items= item};
            return View(model);
            
        }
        public IActionResult GetTotalQuantity(int? StoreId, int? ItemId) 
        {
            var Total_Quantity = _context.StoresAndItems.Where
                (a => a.Store_Id == StoreId && a.Item_Id == ItemId).Sum(a => a.Quantity);
            return Ok(Total_Quantity);
		}
    }
}
