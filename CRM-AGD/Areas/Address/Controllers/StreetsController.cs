using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Address.Data;
using CRM_AGD.Areas.Address.Models;

namespace CRM_AGD.Areas.Address.Controllers
{
    [Area("Address")]
    public class StreetsController : Controller
    {
        private readonly AddressContext _context;

        public StreetsController(AddressContext context)
        {
            _context = context;
        }

        // GET: Address/Streets
        public async Task<IActionResult> Index()
        {
            var addressContext = _context.Streets.Include(s => s.city).Include(s => s.streetPrefix);
            return View(await addressContext.ToListAsync());
        }

        // GET: Address/Streets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var street = await _context.Streets
                .Include(s => s.city)
                .Include(s => s.streetPrefix)
                .SingleOrDefaultAsync(m => m.StreetId == id);
            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        // GET: Address/Streets/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "StreetPrefixId", "StreetPrefixId");
            return View();
        }

        // POST: Address/Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetId,Name,CityId,StreetPrefixId")] Street street)
        {
            if (ModelState.IsValid)
            {
                _context.Add(street);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", street.CityId);
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "StreetPrefixId", "StreetPrefixId", street.StreetPrefixId);
            return View(street);
        }

        // GET: Address/Streets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var street = await _context.Streets.SingleOrDefaultAsync(m => m.StreetId == id);
            if (street == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", street.CityId);
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "StreetPrefixId", "StreetPrefixId", street.StreetPrefixId);
            return View(street);
        }

        // POST: Address/Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StreetId,Name,CityId,StreetPrefixId")] Street street)
        {
            if (id != street.StreetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(street);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreetExists(street.StreetId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", street.CityId);
            ViewData["StreetPrefixId"] = new SelectList(_context.StreetPrefixes, "StreetPrefixId", "StreetPrefixId", street.StreetPrefixId);
            return View(street);
        }

        // GET: Address/Streets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var street = await _context.Streets
                .Include(s => s.city)
                .Include(s => s.streetPrefix)
                .SingleOrDefaultAsync(m => m.StreetId == id);
            if (street == null)
            {
                return NotFound();
            }

            return View(street);
        }

        // POST: Address/Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var street = await _context.Streets.SingleOrDefaultAsync(m => m.StreetId == id);
            _context.Streets.Remove(street);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreetExists(int id)
        {
            return _context.Streets.Any(e => e.StreetId == id);
        }
    }
}
