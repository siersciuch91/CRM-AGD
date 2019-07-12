using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Address.Models
{
    public class Street : IStreet
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
                if (streetPrefix != null && city != null)
                    return string.Format("{0} {1} - {2}", streetPrefix.Prefix, Name, city.Name).Trim();

                return "";
            }
        }

        public string Description => ToString();
        public override string ToString()
        {
            if (streetPrefix != null && city != null)
                return $"{streetPrefix.Prefix} {Name} - {city.Name}".Trim();

            return Name;
        }


        public virtual string FullNameWithOutCityName
        {
            get
            {
                if (streetPrefix != null && city != null)
                    return string.Format("{0} {1}", streetPrefix.Prefix, Name).Trim();

                return "";
            }
        }
    }
}
