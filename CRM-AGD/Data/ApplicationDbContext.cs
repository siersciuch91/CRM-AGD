using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Models;
using CRM_AGD.Areas.Address.Models;
using CRM_AGD.Areas.Client.Models;
using CRM_AGD.Areas.Equipment.Models;

namespace CRM_AGD.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Client> Client { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<StreetPrefix> StreetPrefixes { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Manufacturer> Manufacturer { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<CRM_AGD.Areas.Equipment.Models.MachineType> MachineType { get; set; }

    public DbSet<CRM_AGD.Areas.Equipment.Models.MachineModel> MachineModel { get; set; }
  }
}
