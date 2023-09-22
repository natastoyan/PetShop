using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Core
{
	public interface IShopingCartManager
	{
		public AddToCartResponse AddToCart(AddToCartRequest request);

		public AddToCartItem[] GetItem();
	}
}
