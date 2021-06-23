using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.MVC.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options):base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, Name = "Baseball" });
			modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, Name = "Football" });

			modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, Name = "Ryne Sandberg", Price = 2.30M, CategoryId = 1 });
			modelBuilder.Entity<Product>().HasData(new Product { ProductId = 2, Name = "Drew Brees", Price = 1.30M, CategoryId = 2 });
		}
	}
}
