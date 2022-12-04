using DataConcurrencyWithEFCore.DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataConcurrencyWithEFCore.DataLayer;

public class NorthwindDataContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=Northwind;User Id=sa;Password=Passw0rd;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasIndex(p => p.CustomerID);
        modelBuilder.Entity<Customer>().Property(p => p.ContactTitle).IsRequired(false);
        modelBuilder.Entity<Customer>().Property(p => p.PostalCode).IsRequired(false);
        modelBuilder.Entity<Customer>().Property(p => p.Address).IsRequired(false);
        modelBuilder.Entity<Customer>().Property(p => p.City).IsRequired(false);
        modelBuilder.Entity<Customer>().Property(p => p.Fax).IsRequired(false);
        modelBuilder.Entity<Customer>().Property(p => p.Country).IsRequired(false);
        modelBuilder.Entity<Customer>().Property(p => p.Phone).IsRequired(false);
        modelBuilder.Entity<Customer>().Property(p => p.Region).IsRequired(false);

        modelBuilder.Entity<Customer>().Property(p => p.RowVersion).IsConcurrencyToken().IsRowVersion();

        modelBuilder.Entity<Region>().HasIndex(p => p.RegionID);
        modelBuilder.Entity<Region>().Property(p => p.RegionDescription).IsRequired();
        modelBuilder.Entity<Region>().Property(p => p.RowDateNew2)
            .IsConcurrencyToken();
    }
}