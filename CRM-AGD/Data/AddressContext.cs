using CRM_AGD.Models;
using CRM_AGD.Models.Address;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Data
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
