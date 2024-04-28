using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class ItemController : Controller
	{
		private readonly Demo_dbcontext _context;

		public ItemController(Demo_dbcontext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var model = _context.Items.ToList();
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
				_context.Items.Add(model);
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
			var model = _context.Items.FirstOrDefault(a => a.Id == id);
			if (model == null)
				return NotFound();
			return View(model);

		}
		[HttpPost]
		public IActionResult Edit(Item item)
		{
			var Old_item = _context.Items.FirstOrDefault(a => a.Id == item.Id);
			Old_item.Item_Name = item.Item_Name;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int? id)
		{
			if (id == null)
				return BadRequest();
			var model = _context.Items.FirstOrDefault(a => a.Id == id);
			if (model == null)
				return NotFound();
			_context.Remove(model);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
