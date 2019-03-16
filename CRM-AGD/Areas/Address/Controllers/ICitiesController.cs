using System.Threading.Tasks;
using CRM_AGD.Areas.Address.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM_AGD.Areas.Address.Controllers
{
  public interface ICitiesController
  {
    IActionResult Create();
    Task<IActionResult> Create([Bind(new[] { "CityId,Name" })] City city);
    Task<IActionResult> Delete(int? id);
    Task<IActionResult> DeleteConfirmed(int id);
    Task<IActionResult> Details(int? id);
    Task<IActionResult> Edit(int id, [Bind(new[] { "CityId,Name" })] City city);
    Task<IActionResult> Edit(int? id);
    Task<IActionResult> Index();
  }
}