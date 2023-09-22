using Moq;
using NUnit.Framework;
using Moq.EntityFrameworkCore;

namespace PetShop.Core
{
	
	public class DBShoppingCartTests
	{
		[SetUp]
		public void SetUp()
		{

		}

		[Test]
		public void ShouldReturnItemAddedToShoppingCart()
		{
			var initialItems = new AddToCartArticle[]
			{
				new AddToCartArticle
				{
					Id = 42,
					Quantity = 5
				}
			};

			var mockContext = new Mock<ShoppingCartContext>();
			mockContext.Setup(ctx => ctx.Items).ReturnsDbSet(initialItems);

			//var manager = new ShoppingCartManager();
			var manager = new DbShoppingCartManager(mockContext.Object);

		
			var items = manager.GetCart();
			Assert.AreEqual(initialItems, items);
		}

	}
}
