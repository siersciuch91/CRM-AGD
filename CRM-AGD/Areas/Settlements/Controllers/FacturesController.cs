using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Settlements.Models;
using CRM_AGD.Data;
using Microsoft.AspNetCore.Authorization;

namespace CRM_AGD.Areas.Settlements.Controllers
{
    [Area("Settlements")]
  [Authorize]
  public class FacturesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public FacturesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Settlements/Factures
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.Facture.Include(f => f.client);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Settlements/Factures/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var facture = await _context.Facture
          .Include(f => f.client)
          .SingleOrDefaultAsync(m => m.FactureId == id);
      if (facture == null)
      {
        return NotFound();
      }

      return View(facture);
    }

    // GET: Settlements/Factures/Create
    public IActionResult Create()
    {
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress");
      return View();
    }

    // POST: Settlements/Factures/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FactureId,CreateDate,ClientId,SumNetto,SumBrutto")] Facture facture)
    {
      if (ModelState.IsValid)
      {
        _context.Add(facture);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress", facture.ClientId);
      return View(facture);
    }

    // GET: Settlements/Factures/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var facture = await _context.Facture.SingleOrDefaultAsync(m => m.FactureId == id);
      if (facture == null)
      {
        return NotFound();
      }
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress", facture.ClientId);
      return View(facture);
    }

    // POST: Settlements/Factures/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("FactureId,CreateDate,ClientId,SumNetto,SumBrutto")] Facture facture)
    {
      if (id != facture.FactureId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(facture);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!FactureExists(facture.FactureId))
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
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress", facture.ClientId);
      return View(facture);
    }

    // GET: Settlements/Factures/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var facture = await _context.Facture
          .Include(f => f.client)
          .SingleOrDefaultAsync(m => m.FactureId == id);
      if (facture == null)
      {
        return NotFound();
      }

      return View(facture);
    }

    // POST: Settlements/Factures/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var facture = await _context.Facture.SingleOrDefaultAsync(m => m.FactureId == id);
      _context.Facture.Remove(facture);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool FactureExists(int id)
    {
      return _context.Facture.Any(e => e.FactureId == id);
    }
  }
}
