using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Equipment.Models
{
  public class MachineModel
  {
    public int MachineModelId { get; set; }
    public int ManufacturerId { get; set; }
    public int MachineTypeId { get; set; }

    [StringLength(40, ErrorMessage = "Model name cannot be longer than 40 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string Model { get; set; }

    [DisplayName("Manufacturer")]
    public Manufacturer manufacturer { get; set; }

    [DisplayName("Type")]
    public MachineType machineType { get; set; }
  }
}
