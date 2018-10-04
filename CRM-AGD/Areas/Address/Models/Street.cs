using System.ComponentModel;

namespace CRM_AGD.Areas.Address.Models
{
  public class Street
  {
    public int StreetId { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public int StreetPrefixId { get; set; }

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
  }
}
