﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Data;
using CRM_AGD.Models;

namespace CRM_AGD.Controllers
{
    public class StreetPrefixesController : Controller
    {
        private readonly CrmContext _context;

        public StreetPrefixesController(CrmContext context)
        {
            _context = context;
        }

        // GET: StreetPrefixes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StreetPrefixes.ToListAsync());
        }

        // GET: StreetPrefixes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetPrefix = await _context.StreetPrefixes
                .SingleOrDefaultAsync(m => m.StreetPrefixId == id);
            if (streetPrefix == null)
            {
                return NotFound();
            }

            return View(streetPrefix);
        }

        // GET: StreetPrefixes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StreetPrefixes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prefix,StreetPrefixId")] StreetPrefix streetPrefix)
        {
            if (ModelState.IsValid)
            {
                _context.Add(streetPrefix);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(streetPrefix);
        }

        // GET: StreetPrefixes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetPrefix = await _context.StreetPrefixes.SingleOrDefaultAsync(m => m.StreetPrefixId == id);
            if (streetPrefix == null)
            {
                return NotFound();
            }
            return View(streetPrefix);
        }

        // POST: StreetPrefixes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Prefix,StreetPrefixId")] StreetPrefix streetPrefix)
        {
            if (id != streetPrefix.StreetPrefixId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(streetPrefix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreetPrefixExists(streetPrefix.StreetPrefixId))
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
            return View(streetPrefix);
        }

        // GET: StreetPrefixes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetPrefix = await _context.StreetPrefixes
                .SingleOrDefaultAsync(m => m.StreetPrefixId == id);
            if (streetPrefix == null)
            {
                return NotFound();
            }

            return View(streetPrefix);
        }

        // POST: StreetPrefixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var streetPrefix = await _context.StreetPrefixes.SingleOrDefaultAsync(m => m.StreetPrefixId == id);
            _context.StreetPrefixes.Remove(streetPrefix);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreetPrefixExists(int id)
        {
            return _context.StreetPrefixes.Any(e => e.StreetPrefixId == id);
        }
    }
}
