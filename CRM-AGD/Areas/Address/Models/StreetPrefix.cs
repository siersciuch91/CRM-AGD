using System.ComponentModel.DataAnnotations;
using System.Linq;
using CRM_AGD.Data;
using NonFactors.Mvc.Lookup;

namespace CRM_AGD.Areas.Address.Models
{
  public class StreetPrefix
  {
    [Key]
    public int StreetPrefixId { get; set; }

    [LookupColumn]
    [Display(Name = "Prefix")]
    public string Prefix { get; set; }
  }

  public class StreetPrefixLookup : MvcLookup<StreetPrefix>
  {
    private ApplicationDbContext Context { get; }

    public StreetPrefixLookup(ApplicationDbContext context)
    {
      Context = context;
    }

    public StreetPrefixLookup()
    {
      Url = "AllStreetPrefix";
      Title = "Street prefix";

      Filter.Sort = "Prefix";
      Filter.Order = LookupSortOrder.Desc;
    }

    public override IQueryable<StreetPrefix> GetModels()
    {
      return Context.Set<StreetPrefix>();
    }
  }
}
