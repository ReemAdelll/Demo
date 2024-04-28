using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
	public class StoreController : Controller
	{
		private readonly Demo_dbcontext _context;

		public StoreController(Demo_dbcontext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var model = _context.Stores.ToList();
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
				_context.Stores.Add(model);
				_context.SaveChanges();
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
			if (id == null)
				return BadRequest();
			var model = _context.Stores.FirstOrDefault(a => a.Id == id);
			if (model == null)
				return NotFound();
			return View(model);

		}
		[HttpPost]
		public IActionResult Edit(Store store)
		{
			var Old_Store = _context.Stores.FirstOrDefault(a => a.Id == store.Id);
			Old_Store.Store_Name = store.Store_Name;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int? id)
		{

			if (id == null)
				return BadRequest();
			var model = _context.Stores.FirstOrDefault(a => a.Id == id);
			if (model == null)
				return NotFound();
			_context.Remove(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
