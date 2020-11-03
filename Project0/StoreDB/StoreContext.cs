using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreLib.Models;

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

        var connectionString = configuration.GetConnectionString("StoreDB");
        optionsBuilder.UseNpgsql(connectionString);
      }
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder) {

    //     modelBuilder.Entity<Order>()
    //     .HasOne(e => e.PriceStr)
    //     .WithMany("Items")
    //     .HasForeignKey(e => e.Id);

    //     modelBuilder.Entity<Customer>()
    //     .HasOne(e => e.Name)
    //     .WithMany("Items")
    //     .HasForeignKey(e => e.Id);

    //     modelBuilder.Entity<Product>()
    //     .HasOne(e => e.Name)
    //     .WithOne("Items")
    //     .HasForeignKey("Id");

    //     modelBuilder.Entity<Employee>()
    //     .HasOne(e => e.Name)
    //     .WithOne("Id1")
    //     .HasForeignKey("ID");

    // }

  }
}