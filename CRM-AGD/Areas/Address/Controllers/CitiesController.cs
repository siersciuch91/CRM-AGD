using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Address.Models;
using CRM_AGD.Data;
using Microsoft.AspNetCore.Authorization;

namespace CRM_AGD.Areas.Address.Controllers
{
  [Area("Address")]
  [Authorize]
  public class CitiesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public CitiesController(ApplicationDbContext context)
    {
      _context = context;
    }

    //GET: Address/Cities
    public async Task<IActionResult> Index()
    { 
      return View(await _context.Cities.OrderBy(c => c.Name).ToListAsync());

    }

    // GET: Address/Cities/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var city = await _context.Cities
          .SingleOrDefaultAsync(m => m.CityId == id);
      if (city == null)
      {
        return NotFound();
      }

      var streets = _context.Streets
        .Where(s => s.CityId == city.CityId)
        .Include(s => s.city)
        .Include(s => s.streetPrefix);


      ViewBag.Streets = streets.ToList();
      return View(city);
    }

    // GET: Address/Cities/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Address/Cities/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CityId,Name")] City city)
    {
      if (ModelState.IsValid)
      {
        _context.Add(city);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(city);
    }

    // GET: Address/Cities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var city = await _context.Cities.SingleOrDefaultAsync(m => m.CityId == id);
      if (city == null)
      {
        return NotFound();
      }
      return View(city);
    }

    // POST: Address/Cities/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CityId,Name")] City city)
    {
      if (id != city.CityId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(city);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CityExists(city.CityId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(city);
    }

    // GET: Address/Cities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var city = await _context.Cities
          .SingleOrDefaultAsync(m => m.CityId == id);
      if (city == null)
      {
        return NotFound();
      }

      return View(city);
    }

    // POST: Address/Cities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var city = await _context.Cities.SingleOrDefaultAsync(m => m.CityId == id);
      _context.Cities.Remove(city);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CityExists(int id)
    {
      return _context.Cities.Any(e => e.CityId == id);
    }
  }
}
