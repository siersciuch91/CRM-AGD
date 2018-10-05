using CRM_AGD.Areas.Address.Models;
using CRM_AGD.Areas.Equipment.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Client.Models
{
  public class IssueFromPortal
  {
    public int IssueId { get; set; }
    public int MachineModelId { get; set; }

    [DisplayName("First name")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
    [Required(ErrorMessage = "Field can't be empty")]
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public int StreetId { get; set; }
    public string HomeNumber { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime SuggestedDate { get; set; }
    public string Description { get; set; }

    [DisplayName("Street")]
    public Street street { get; set; }

    [DisplayName("Machine model")]
    public MachineModel machineModel { get; set; }
  }
}
