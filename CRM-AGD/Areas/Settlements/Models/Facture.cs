using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Settlements.Models
{
  public class Facture
  {
    public int FactureId { get; set; }
    public DateTime CreateDate { get; set; }
    public int ClientId { get; set; }
    public double SumNett { get; set; }
    public double SumBrutto { get; set; }
  }
}
