﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EqDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EqDemo
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{ }

		#region NWind

		//public DbSet<Asin> Categor1ies { get; set; }
		public DbSet<Category> Categories { get; set; }

		public DbSet<Category1> Categories1 { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Order> Orders { get; set; }

		public DbSet<Product> Products { get; set; }
		public DbSet<Shipper> Shippers { get; set; }

		public DbSet<Supplier> Suppliers { get; set; }

		#endregion NWind

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderDetail>()
				.ToTable("Order_Details")
				.HasKey(od => new { od.OrderID, od.ProductID });
		}
	}
}