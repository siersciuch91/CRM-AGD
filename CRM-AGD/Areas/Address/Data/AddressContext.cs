using CRM_AGD.Areas.Address.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_AGD.Areas.Address.Data
{
  public class AddressContext : DbContext
  {
    public AddressContext(DbContextOptions<AddressContext> options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<StreetPrefix> StreetPrefixes { get; set; }
    public DbSet<Street> Streets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<City>().ToTable("City").HasKey(c => new { c.CityId });
      modelBuilder.Entity<StreetPrefix>().ToTable("StreetPrefix").HasKey(c => new { c.StreetPrefixId });
      modelBuilder.Entity<Street>().ToTable("Street").HasKey(c => new { c.StreetId });
    }
  }
}
