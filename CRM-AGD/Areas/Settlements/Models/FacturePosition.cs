using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Settlements.Models
{
  public class FacturePosition
  {
    public int FacturePositionId { get; set; }

    public int FactureId { get; set; }

    public int VatRatesId { get; set; }

    [Required(ErrorMessage = "Field can't be empty")]
    public double Netto { get; set; }

    [Required(ErrorMessage = "Field can't be empty")]
    public double Brutto { get; set; }

    public string Description { get; set; } = "";

    [DisplayName("Facture")]
    public Facture facture { get; set; }

    [DisplayName("VAT percent")]
    [Required(ErrorMessage = "Field can't be empty")]
    public VatRates vatRates { get; set; }
  }
}
