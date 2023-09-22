using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Core
{
	internal class ShoppingCartManager : IShopingCartManager
	{
		private System.Collections.Generic.List<AddToCartItem> _shoppingCart;
		public ShoppingCartManager()
		{
			_shoppingCart = new List<AddToCartItem>();
		}

		public AddToCartResponse AddToCart(AddToCartRequest request)
		{
			if (_shoppingCart.Any(_ => _.Id == request.Item.Id))
			{
				_shoppingCart.Where(_ => _.Id == request.Item.Id)
					.Select(_ => 
					{
						_.Quantity += request.Item.Quantity;
					return _; 
					}).ToList();
			}
			else
				_shoppingCart.Add(request.Item);
			return new AddToCartResponse()
			{
				Items = _shoppingCart.ToArray(),
			};
		}

		public AddToCartItem[] GetItem()
		{
			return _shoppingCart.ToArray();
		}
	}
}