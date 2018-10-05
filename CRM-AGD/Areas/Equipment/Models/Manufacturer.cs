using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Equipment.Models
{
  public class Manufacturer
  {
    public int ManufacturerId { get; set; }

    [StringLength(50, ErrorMessage = "Manufacturer name cannot be longer than 50 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string Name { get; set; }
  }
}
