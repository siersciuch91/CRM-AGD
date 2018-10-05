using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Address.Models
{
  public class City
  {
    public int CityId { get; set; }

    [StringLength(100, ErrorMessage = "City name cannot be longer than 100 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string Name { get; set; }
  }
}
