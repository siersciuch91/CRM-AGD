using CRM_AGD.Areas.Equipment.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Client.Models
{
  public class Issue
  {
    public int IssueId { get; set; }
    public int ClientId { get; set; }
    public int MachineModelId { get; set; }
    public DateTime CreateDate = DateTime.Now;

    [DisplayName("Repair term")]
    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Field can't be empty")]
    public DateTime Term { get; set; }

    public string Description { get; set; }

    [DisplayName("Client")]
    public Client client { get; set; }

    [DisplayName("Machine model")]
    public MachineModel machineModel { get; set; }
  }
}
