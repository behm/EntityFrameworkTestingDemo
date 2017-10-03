using FakeItEasy;
using FakeItEasyTestingDemo.Data;
using FakeItEasyTestingDemo.Models;
using FakeItEasyTestingDemo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeItEasyTestingDemo.Tests
{
	[TestClass]
	public class ProductServiceTests
	{
		[TestMethod]
		public void GetAll_ReturnsAllProducts()
		{
			//Arrange
			var data = new List<Product>
			{
				new Product { Id = 1, Name = "Widget", InStock = true },
				new Product { Id = 2, Name = "Gadget", InStock = true },
				new Product { Id = 3, Name = "Thingy", InStock = true },
				new Product { Id = 4, Name = "Whirlyjig", InStock = true },
			};

			var set = A.Fake<DbSet<Product>>(o => o.Implements(typeof(IQueryable<Product>)).Implements(typeof(IDbAsyncEnumerable<Product>))).SetupData(data);

			var context = A.Fake<AcmeContext>();
			A.CallTo(() => context.Products).Returns(set);

			IProductService service = new ProductService(context);

			//Act 
			var results = service.GetAll();

			//Assert
			Assert.AreEqual(4, results.Count());
		}

		[TestMethod]
		public void GetInStockProducts_ReturnsOnlyInStockProducts()
		{
			//Arrange
			var data = new List<Product>
			{
				new Product { Id = 1, Name = "Widget", InStock = true },
				new Product { Id = 2, Name = "Gadget", InStock = true },
				new Product { Id = 3, Name = "Thingy", InStock = false },
				new Product { Id = 4, Name = "Whirlyjig", InStock = true },
			};

			var set = A.Fake<DbSet<Product>>(o => o.Implements(typeof(IQueryable<Product>)).Implements(typeof(IDbAsyncEnumerable<Product>))).SetupData(data);

			var context = A.Fake<AcmeContext>();
			A.CallTo(() => context.Products).Returns(set);

			IProductService service = new ProductService(context);

			//Act 
			var results = service.GetInStockProducts();

			//Assert
			Assert.IsTrue(results.Count(p => p.InStock == true) == 3);
			Assert.IsTrue(results.Count(p => p.InStock == false) == 0);
		}
	}
}
