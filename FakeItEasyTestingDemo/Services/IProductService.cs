using System.Collections.Generic;
using FakeItEasyTestingDemo.Models;

namespace FakeItEasyTestingDemo.Services
{
	public interface IProductService
	{
		IEnumerable<Product> GetAll();
		IEnumerable<Product> GetInStockProducts();
		Product GetProduct(int id);
	}
}