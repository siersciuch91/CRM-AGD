using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_AGD.Models.Address
{
  public class Street
  {
    public int StreetId { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public int StreetPrefixId { get; set; }

    public StreetPrefix streetPrefix { get; set; }
    public City city { get; set; }
  }
}
