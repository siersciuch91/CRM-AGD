using CRM_AGD.Areas.Address.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Client.Models
{
  public class Client
  {
    public int ClientId { get; set; }
    [DisplayName("First name")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string FirstName { get; set; }
    [DisplayName("Second name")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string SecondName { get; set; }
    [DisplayName("Email")]
    [Required(ErrorMessage = "Field can't be empty")]
    [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
    public string EmailAddress { get; set; }
    [DisplayName("Phone")]
    [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "Phone number must have 9 number")]
    [RegularExpression(@"^[0-9]+", ErrorMessage = "Phone number must have 9 number")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Field can't be empty")]
    [DisplayName("Street")]
    public int StreetId { get; set; }
    [DisplayName("Home no.")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string HomeNumber { get; set; }

    [DisplayName("Street")]
    public Street street { get; set; }
  }
}
