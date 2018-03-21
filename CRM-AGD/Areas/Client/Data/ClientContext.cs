using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Client.Data
{
  public class ClientContext : DbContext
  {
    public ClientContext(DbContextOptions<ClientContext> options) : base(options)
    {
    }
  }
}
