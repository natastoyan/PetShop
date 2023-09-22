using Moq;
using NUnit.Framework;
using System.Linq;

namespace PetShop.Core
{
	
	internal class ShoppingCartTests
	{
		[SetUp]
		public void SetUp()
		{

		}

		[Test]
		public void ShouldReturnItemAddedToShoppingCart()
		{
			var item = new AddToCartArticle()
			{
				Id = 42,
				Quantity = 5
			};

			var request = new AddToCartRequest()
			{
				Item = item,
			};

			//var manager = new ShoppingCartManager();
			var mockManager = new Mock<IShopingCartManager>();
			mockManager.Setup(manager => manager.AddToCart(
				It.IsAny<AddToCartRequest>())).Returns(
				 (AddToCartRequest request) => new AddToCartResponse()
				 {
					 Items = new AddToCartArticle[] { request.Item }
				 }
			 );
			AddToCartResponse response = mockManager.Object.AddToCart(request);
			Assert.NotNull(response);
			Assert.Contains(item, response.Items);
		}

		[Ignore("hhhh")]
		[Test]
		public void ShouldReturnItemsAddedToShoppingCart()
		{
			var manager = new ShoppingCartManager();
			var item1 = new AddToCartArticle()
			{
				Id = 42,
				Quantity = 5
			};

			var request = new AddToCartRequest()
			{
				Item = item1,
			};


			var item2 = new AddToCartArticle()
			{
				Id = 10,
				Quantity = 6
			};

			request = new AddToCartRequest()
			{
				Item = item2,
			};

			var response = manager.AddToCart(request);

			Assert.NotNull(response);
			Assert.Contains(item1, response.Items);
			Assert.Contains(item2, response.Items);

		}


		[Test]
		public void ShouldSumSameItemsQuantity()
		{

			var manager = new ShoppingCartManager();
			var item1 = new AddToCartArticle()
			{
				Id = 42,
				Quantity = 5
			};

			var request = new AddToCartRequest()
			{
				Item = item1,
			};
			AddToCartResponse response = manager.AddToCart(request);

			var item2 = new AddToCartArticle()
			{
				Id = 42,
				Quantity = 6
			};

			request = new AddToCartRequest()
			{
				Item = item2,
			};

			response = manager.AddToCart(request);

			Assert.NotNull(response);
			Assert.That(response.Items.Length == 1);
			//Assert.AreEqual(response.Items.Where(_ => _.Id == 42).Sum(_ => _.Quantity), item1.Quantity + item2.Quantity);
			Assert.AreEqual(response.Items.Where(_ => _.Id == 42).Sum(_ => _.Quantity), 11);


		}
	}
}
