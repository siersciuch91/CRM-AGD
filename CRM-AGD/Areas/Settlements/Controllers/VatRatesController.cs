using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Settlements.Models;
using CRM_AGD.Data;

namespace CRM_AGD.Areas.Settlements.Controllers
{
    [Area("Settlements")]
    public class VatRatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VatRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Settlements/VatRates
        public async Task<IActionResult> Index()
        {
            return View(await _context.VatRates.ToListAsync());
        }

        // GET: Settlements/VatRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatRates = await _context.VatRates
                .SingleOrDefaultAsync(m => m.VatRatesId == id);
            if (vatRates == null)
            {
                return NotFound();
            }

            return View(vatRates);
        }

        // GET: Settlements/VatRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Settlements/VatRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VatRatesId,Value")] VatRates vatRates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vatRates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vatRates);
        }

        // GET: Settlements/VatRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatRates = await _context.VatRates.SingleOrDefaultAsync(m => m.VatRatesId == id);
            if (vatRates == null)
            {
                return NotFound();
            }
            return View(vatRates);
        }

        // POST: Settlements/VatRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VatRatesId,Value")] VatRates vatRates)
        {
            if (id != vatRates.VatRatesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vatRates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VatRatesExists(vatRates.VatRatesId))
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
            return View(vatRates);
        }

        // GET: Settlements/VatRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatRates = await _context.VatRates
                .SingleOrDefaultAsync(m => m.VatRatesId == id);
            if (vatRates == null)
            {
                return NotFound();
            }

            return View(vatRates);
        }

        // POST: Settlements/VatRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vatRates = await _context.VatRates.SingleOrDefaultAsync(m => m.VatRatesId == id);
            _context.VatRates.Remove(vatRates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VatRatesExists(int id)
        {
            return _context.VatRates.Any(e => e.VatRatesId == id);
        }
    }
}
