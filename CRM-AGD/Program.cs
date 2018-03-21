using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM_AGD.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CRM_AGD.Areas.Address.Data;
using CRM_AGD.Areas.Equipment.Data;
using CRM_AGD.Areas.Client.Data;

namespace CRM_AGD
{
  public class Program
  {
    public static void Main(string[] args)
    {

      var host = BuildWebHost(args);

      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        try
        {
          var contextAddress = services.GetRequiredService<AddressContext>();
          contextAddress.Database.EnsureCreated();

          var contextEquipment = services.GetRequiredService<EquipmentContext>();
          contextEquipment.Database.EnsureCreated();

          var contextClient = services.GetRequiredService<ClientContext>();
          contextClient.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred while seeding the database.");
        }
      }

      host.Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}
