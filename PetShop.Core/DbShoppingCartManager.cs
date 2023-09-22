using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Core
{
	public class DbShoppingCartManager : IShopingCartManager
	{
		private readonly ShoppingCartContext _db;

		public DbShoppingCartManager(ShoppingCartContext db)
		{
			_db = db;
		}

		public AddToCartResponse AddToCart(AddToCartRequest request)
		{
			var item = _db.Items.FirstOrDefault(i => i.Id == request.Item.Id);
			if (item == null)
			{
				item.Quantity += request.Item.Quantity;
			}
			else
			{
				_db.Items.Add(item);	
			}
			_db.SaveChanges();

			return new AddToCartResponse()
			{
				Items = _db.Items.ToArray()
			};
		}

		public IEnumerable<AddToCartArticle> GetCart()
		{
			return _db.Items.ToArray();
		}
	}
}
