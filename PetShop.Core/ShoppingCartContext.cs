
using Microsoft.EntityFrameworkCore;

namespace PetShop.Core
{
	public class ShoppingCartContext : DbContext
	{
		public virtual DbSet<AddToCartArticle> Items { get; set; }
	}
}