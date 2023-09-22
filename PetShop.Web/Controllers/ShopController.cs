using Microsoft.AspNetCore.Mvc;
using PetShop.Core;

namespace PetShop.Web.Controllers
{
	public class ShopController : Controller
	{
		private List<Article> _articles = new List<Article>()
		{
			new Article() { Id = 1, Name = "Red T-Short", Price = 20 },
			new Article() { Id = 2, Name = "Blue T-Short", Price = 20 },
			new Article() { Id = 3, Name = "Green Windbreaker", Price = 10 }
		};

		public IActionResult Index(string query)
		{
			var model = _articles;
			if(!string.IsNullOrEmpty(query))
			{
				model = _articles.Where(a => a.Name.ToLower().Contains(query.ToLower())).ToList();
			}

			return View(model);
		}
	}
}
