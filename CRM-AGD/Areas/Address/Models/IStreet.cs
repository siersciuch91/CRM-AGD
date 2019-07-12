namespace CRM_AGD.Areas.Address.Models
{
    public interface IStreet
    {
        int StreetId { get; set; }
        string Name { get; set; }
        int CityId { get; set; }
        int StreetPrefixId { get; set; }
        string PostCode { get; set; }
        StreetPrefix streetPrefix { get; set; }
        City city { get; set; }
        string FullName { get; }
        string FullNameWithOutCityName { get; }
    }
}