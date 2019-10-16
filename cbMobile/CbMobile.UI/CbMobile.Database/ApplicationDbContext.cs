using CbMobile.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<OrderManuFacturer> OrderManuFacturers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<DetailSpecification> DetailSpecifications { get; set; }
        public DbSet<MainMemory> MainMemorys { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
