using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_AGD.Areas.Equipment.Models;

namespace CRM_AGD.Areas.Equipment.Data
{
  public class EquipmentContext : DbContext
  {
    public EquipmentContext(DbContextOptions<EquipmentContext> options) : base(options)
    {
    }
    public DbSet<Manufacturer> Manufacturer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer").HasKey(m => new { m.ManufacturerId});
    }
  }
}
