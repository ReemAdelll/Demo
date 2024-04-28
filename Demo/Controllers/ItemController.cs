using Demo.Models;
using Demo.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class ItemController : Controller
	{
		
		private readonly IItemRepo _IItemRepo;

		public ItemController(IItemRepo IRepo)
		{
			
			_IItemRepo = IRepo;
		}

		public IActionResult Index()
		{
			var model = _IItemRepo.show();
			return View(model);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Item model)
		{
			if (model.Item_Name?.Length > 2)
			{
				_IItemRepo.Add(model);
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
			
			var model = _IItemRepo.GetById(id.Value);
			return View(model);

		}
		[HttpPost]
		public IActionResult Edit(Item item)
		{
			_IItemRepo.Update(item);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int? id)
		{
			if (!id.HasValue)
				return BadRequest();
            _IItemRepo.Delete(id.Value);
            return RedirectToAction("Index");
		}
	}
}
