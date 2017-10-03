using FakeItEasyTestingDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FakeItEasyTestingDemo.Data
{
	public class AcmeContext : DbContext
	{
		public virtual DbSet<Product> Products { get; set; }
	}
}