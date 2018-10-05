using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Settlements.Models
{
  public class FacturePosition
  {
    public int FacturePositionId { get; set; }
    public int FactureId { get; set; }
    public int VatRatesId { get; set; }
    public double Netto { get; set; }
    public double Brutto { get; set; }
    public string Description { get; set; }
  }
}
