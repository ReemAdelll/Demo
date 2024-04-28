using Demo.Models;
using Demo.Repos;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StoreItemViewModelController : Controller
    {
        
        private readonly IStoreItemRepo _IStoreItemRepo;

        public StoreItemViewModelController(IStoreItemRepo IRepo)
        {

            _IStoreItemRepo = IRepo;
        }
        public IActionResult Index()
        {
            var model = _IStoreItemRepo.show();
            return View(model);
            
        }
        public IActionResult GetTotalQuantity(int? StoreId, int? ItemId) 
        {
            var Total_Quantity = _IStoreItemRepo.GetQuantity(StoreId.Value, ItemId.Value);
            return Ok(Total_Quantity);
		}
        [HttpPost]
		public IActionResult Index(StoreItemViewModel viewmodel)
        {
            var model = _IStoreItemRepo.AddQuantity(viewmodel);
			return View(model);
        }

	}
}
