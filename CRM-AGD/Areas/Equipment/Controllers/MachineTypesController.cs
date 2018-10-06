using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Equipment.Models;
using CRM_AGD.Data;
using Microsoft.AspNetCore.Authorization;

namespace CRM_AGD.Areas.Equipment.Controllers
{
  [Area("Equipment")]
  [Authorize]
  public class MachineTypesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public MachineTypesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Equipment/MachineTypes
    public async Task<IActionResult> Index()
    {
      return View(await _context.MachineType.ToListAsync());
    }

    // GET: Equipment/MachineTypes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var machineType = await _context.MachineType
          .SingleOrDefaultAsync(m => m.MachineTypeId == id);
      if (machineType == null)
      {
        return NotFound();
      }

      return View(machineType);
    }

    // GET: Equipment/MachineTypes/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Equipment/MachineTypes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MachineTypeId,Name")] MachineType machineType)
    {
      if (ModelState.IsValid)
      {
        _context.Add(machineType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(machineType);
    }

    // GET: Equipment/MachineTypes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var machineType = await _context.MachineType.SingleOrDefaultAsync(m => m.MachineTypeId == id);
      if (machineType == null)
      {
        return NotFound();
      }
      return View(machineType);
    }

    // POST: Equipment/MachineTypes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("MachineTypeId,Name")] MachineType machineType)
    {
      if (id != machineType.MachineTypeId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(machineType);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MachineTypeExists(machineType.MachineTypeId))
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
      return View(machineType);
    }

    // GET: Equipment/MachineTypes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var machineType = await _context.MachineType
          .SingleOrDefaultAsync(m => m.MachineTypeId == id);
      if (machineType == null)
      {
        return NotFound();
      }

      return View(machineType);
    }

    // POST: Equipment/MachineTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var machineType = await _context.MachineType.SingleOrDefaultAsync(m => m.MachineTypeId == id);
      _context.MachineType.Remove(machineType);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MachineTypeExists(int id)
    {
      return _context.MachineType.Any(e => e.MachineTypeId == id);
    }
  }
}
