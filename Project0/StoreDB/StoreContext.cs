using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using StoreDB.Models;
using System.Data;

namespace StoreDB
{
  public class StoreContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!(optionsBuilder.IsConfigured))
      {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        //var connectionString = configuration.GetConnectionString("StoreDB");
        string connectionString = @"Host=lallah.db.elephantsql.com;Port=5432;Database=efzgkaao;Username=efzgkaao;Password=wbQfq_L5qqsRTF3VIFhrcjsJfAg2KTuy";
        optionsBuilder.UseNpgsql(connectionString);
      }
    }

    /* protected override void OnModelCreating(ModelBuilder modelBuilder)
     {

       modelBuilder.Entity<Order>()
       .HasOne(ord => ord.)
       .WithMany(o => o.Items)
       .HasForeignKey(e => e.Id);

       modelBuilder.Entity<Customer>()
       .HasOne(e => e.Name)
       .WithMany(cus => cus.)
       .HasForeignKey(e => e.Id);

       modelBuilder.Entity<Product>()
       .HasOne(e => e.Name)
       .WithOne("Items")
       .HasForeignKey("Id");

       modelBuilder.Entity<Employee>()
       .HasOne(e => e.Name)
       .WithOne("Id1")
       .HasForeignKey("ID");

     }*/

  }
}