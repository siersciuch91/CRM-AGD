using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Address.Models
{
  public class StreetPrefix
  {
    public int StreetPrefixId { get; set; }

    [Display(Name = "Prefix")]
    [StringLength(5, ErrorMessage = "Street prefix cannot be longer than 5 characters")]
    public string Prefix { get; set; }
  }
}
