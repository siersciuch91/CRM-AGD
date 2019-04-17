using System.Threading.Tasks;
using CRM_AGD.Areas.Address.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_AGD.Areas.Address.Controllers
{
    public interface IStreetPrefixesController
    {
        IActionResult Create();
        Task<IActionResult> Create([Bind(new[] { "Prefix,StreetPrefixId" })] StreetPrefix streetPrefix);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, [Bind(new[] { "Prefix,StreetPrefixId" })] StreetPrefix streetPrefix);
        Task<IActionResult> Index();
    }
}