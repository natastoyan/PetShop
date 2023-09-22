using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Core
{
	public class ShoppingCartManager : IShopingCartManager
	{
		private List<AddToCartArticle> _shoppingCart;
		public ShoppingCartManager()
		{
			_shoppingCart = new List<AddToCartArticle>();
		}

		public AddToCartResponse AddToCart(AddToCartRequest request)
		{
			if (_shoppingCart.Any(_ => _.Id == request.Item.Id))
			{
				_shoppingCart.Where(_ => _.Id == request.Item.Id).ToList()
					.ForEach(_ => 
					{
						_.Quantity += request.Item.Quantity; 
					});
			}
			else
				_shoppingCart.Add(request.Item);
			return new AddToCartResponse()
			{
				Items = _shoppingCart.ToArray(),
			};
		}

		public IEnumerable<AddToCartArticle> GetCart()
		{
			return _shoppingCart.ToArray();
		}
	}
}