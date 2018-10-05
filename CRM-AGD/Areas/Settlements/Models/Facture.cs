using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Settlements.Models
{
  public class Facture
  {
    public int FactureId { get; set; }

    [DisplayName("Facture date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Field can't be empty")]
    public DateTime CreateDate { get; set; } = DateTime.Now;

    public int ClientId { get; set; }

    [DisplayName("Amount netto")]
    public double SumNetto { get; set; } = 0.00;

    [DisplayName("Amount brutto")]
    public double SumBrutto { get; set; } = 0.00;

    [DisplayName("Client")]
    public CRM_AGD.Areas.Client.Models.Client client { get; set; }
  }
}
