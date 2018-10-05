using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Settlements.Models
{
  public class VatRates
  {
    public int VatRatesId { get; set; }

    [DisplayName("VAT percent")]
    [Required(ErrorMessage = "Field can't be empty")]
    public int Value { get; set; }
  }
}
