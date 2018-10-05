using CRM_AGD.Areas.Address.Models;
using CRM_AGD.Areas.Equipment.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Client.Models
{
  public class IssueFromPortal
  {
    public int IssueFromPortalId { get; set; }

    public int MachineModelId { get; set; }

    [DisplayName("First name")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string FirstName { get; set; }

    [DisplayName("Second name")]
    [StringLength(100, ErrorMessage = "Second name cannot be longer than 100 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string SecondName { get; set; }

    [DisplayName("Email")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
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
    [StringLength(10, ErrorMessage = "Home number cannot be longer than 10 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string HomeNumber { get; set; }

    public DateTime CreateDate = DateTime.Now;

    [DisplayName("Prefered date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Field can't be empty")]
    public DateTime SuggestedDate { get; set; } = DateTime.Now.AddDays(1);

    public string Description { get; set; }

    [DisplayName("Street")]
    public Street street { get; set; }

    [DisplayName("Machine model")]
    public MachineModel machineModel { get; set; }
  }
}
