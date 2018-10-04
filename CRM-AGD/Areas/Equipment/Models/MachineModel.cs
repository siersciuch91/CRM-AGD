using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Equipment.Models
{
  public class MachineModel
  {
    public int MachineModelId { get; set; }
    public int ManufacturerId { get; set; }
    public int MachineTypeId { get; set; }
    public string Model { get; set; }

    [DisplayName("Manufacturer")]
    public Manufacturer manufacturer { get; set; }

    [DisplayName("Type")]
    public MachineType machineType { get; set; }
  }
}
