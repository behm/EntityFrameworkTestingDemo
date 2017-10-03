using FakeItEasyTestingDemo.Data;
using FakeItEasyTestingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeItEasyTestingDemo.Services
{
	public class ProductService : IProductService
	{
		private readonly AcmeContext _context;

		public ProductService(AcmeContext context)
		{
			this._context = context;
		}

		public IEnumerable<Product> GetAll()
		{
			return _context.Products.ToList();
		}

		public IEnumerable<Product> GetInStockProducts()
		{
			return _context.Products.Where(p => p.InStock == true);
		}

		public Product GetProduct(int id)
		{
			return _context.Products.Find(id);
		}
	}
}