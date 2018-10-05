using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Address.Models
{
  public class Street
  {
    public int StreetId { get; set; }

    [StringLength(100, ErrorMessage = "Street name cannot be longer than 100 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string Name { get; set; }

    public int CityId { get; set; }
    public int StreetPrefixId { get; set; }

    [DisplayName("Post code")]
    [StringLength(6, ErrorMessage = "Post code cannot be longer than 6 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    [RegularExpression("[0-9][0-9]-[0-9][0-9][0-9]", ErrorMessage = "Post code is not valid")]
    public string PostCode { get; set; }

    [DisplayName("Prefix")]
    public StreetPrefix streetPrefix { get; set; }

    [DisplayName("City")]
    public City city { get; set; }

    public virtual string FullName
    {
      get
      {
        return string.Format("{0} {1} - {2}",  streetPrefix.Prefix, Name, city.Name).Trim();
      }
    }

    public virtual string FullNameWithOutCityName
    {
      get
      {
        return string.Format("{0} {1}", streetPrefix.Prefix, Name).Trim();
      }
    }
  }
}
