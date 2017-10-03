using FakeItEasyTestingDemo.Data;

namespace FakeItEasyTestingDemo.Services
{
	public class ProductServiceFactory
	{
		public IProductService Create(AcmeContext context)
		{
			return new ProductService(context);
		}
	}
}