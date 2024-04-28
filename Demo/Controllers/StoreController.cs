using Demo.Models;
using Demo.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
	public class StoreController : Controller
	{
        private readonly IStoreRepo _IStoreRepo;

        public StoreController(IStoreRepo IRepo)
        {

            _IStoreRepo = IRepo;
        }
        public IActionResult Index()
		{
            var model = _IStoreRepo.show();
            return View(model);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Store model)
		{
            if (model.Store_Name?.Length > 2)
            {
                _IStoreRepo.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
		[HttpGet]
		public IActionResult Edit(int? id)
		{
            var model = _IStoreRepo.GetById(id.Value);
            return View(model);

		}
		[HttpPost]
		public IActionResult Edit(Store store)
		{
            _IStoreRepo.Update(store);
            return RedirectToAction("Index");
		}
		public IActionResult Delete(int? id)
		{
            if (!id.HasValue)
                return BadRequest();
            _IStoreRepo.Delete(id.Value);
            return RedirectToAction("Index");
		}
	}
}
