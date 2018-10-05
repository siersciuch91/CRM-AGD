using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Equipment.Models
{
  public class MachineType
  {
    public int MachineTypeId { get; set; }

    [StringLength(30, ErrorMessage = "Machine type cannot be longer than 30 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string Name { get; set; }
  }
}
