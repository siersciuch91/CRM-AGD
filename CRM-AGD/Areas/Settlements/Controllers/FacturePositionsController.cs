using System;
using System.Collections.Generic;
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
  public class FacturePositionsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public FacturePositionsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Settlements/FacturePositions
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.FacturePosition.Include(f => f.facture).Include(f => f.vatRates);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Settlements/FacturePositions/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var facturePosition = await _context.FacturePosition
          .Include(f => f.facture)
          .Include(f => f.vatRates)
          .SingleOrDefaultAsync(m => m.FacturePositionId == id);
      if (facturePosition == null)
      {
        return NotFound();
      }

      return View(facturePosition);
    }

    // GET: Settlements/FacturePositions/Create
    public IActionResult Create()
    {
      ViewData["FactureId"] = new SelectList(_context.Facture, "FactureId", "FactureId");
      ViewData["VatRatesId"] = new SelectList(_context.Set<VatRates>(), "VatRatesId", "VatRatesId");
      return View();
    }

    // POST: Settlements/FacturePositions/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FacturePositionId,FactureId,VatRatesId,Netto,Brutto,Description")] FacturePosition facturePosition)
    {
      if (ModelState.IsValid)
      {
        _context.Add(facturePosition);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["FactureId"] = new SelectList(_context.Facture, "FactureId", "FactureId", facturePosition.FactureId);
      ViewData["VatRatesId"] = new SelectList(_context.Set<VatRates>(), "VatRatesId", "VatRatesId", facturePosition.VatRatesId);
      return View(facturePosition);
    }

    // GET: Settlements/FacturePositions/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var facturePosition = await _context.FacturePosition.SingleOrDefaultAsync(m => m.FacturePositionId == id);
      if (facturePosition == null)
      {
        return NotFound();
      }
      ViewData["FactureId"] = new SelectList(_context.Facture, "FactureId", "FactureId", facturePosition.FactureId);
      ViewData["VatRatesId"] = new SelectList(_context.Set<VatRates>(), "VatRatesId", "VatRatesId", facturePosition.VatRatesId);
      return View(facturePosition);
    }

    // POST: Settlements/FacturePositions/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("FacturePositionId,FactureId,VatRatesId,Netto,Brutto,Description")] FacturePosition facturePosition)
    {
      if (id != facturePosition.FacturePositionId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(facturePosition);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!FacturePositionExists(facturePosition.FacturePositionId))
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
      ViewData["FactureId"] = new SelectList(_context.Facture, "FactureId", "FactureId", facturePosition.FactureId);
      ViewData["VatRatesId"] = new SelectList(_context.Set<VatRates>(), "VatRatesId", "VatRatesId", facturePosition.VatRatesId);
      return View(facturePosition);
    }

    // GET: Settlements/FacturePositions/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var facturePosition = await _context.FacturePosition
          .Include(f => f.facture)
          .Include(f => f.vatRates)
          .SingleOrDefaultAsync(m => m.FacturePositionId == id);
      if (facturePosition == null)
      {
        return NotFound();
      }

      return View(facturePosition);
    }

    // POST: Settlements/FacturePositions/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var facturePosition = await _context.FacturePosition.SingleOrDefaultAsync(m => m.FacturePositionId == id);
      _context.FacturePosition.Remove(facturePosition);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool FacturePositionExists(int id)
    {
      return _context.FacturePosition.Any(e => e.FacturePositionId == id);
    }
  }
}
