using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Equipment.Models;
using CRM_AGD.Data;

namespace CRM_AGD.Areas.Equipment.Controllers
{
  [Area("Equipment")]
  public class MachineModelsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public MachineModelsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Equipment/MachineModels
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.MachineModel.Include(m => m.machineType).Include(m => m.manufacturer);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Equipment/MachineModels/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var machineModel = await _context.MachineModel
          .Include(m => m.machineType)
          .Include(m => m.manufacturer)
          .SingleOrDefaultAsync(m => m.MachineModelId == id);
      if (machineModel == null)
      {
        return NotFound();
      }

      ViewData["MachineTypeId"] = new SelectList(_context.MachineType, "MachineTypeId", "Name", machineModel.MachineTypeId);
      ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name", machineModel.ManufacturerId);

      return View(machineModel);
    }

    // GET: Equipment/MachineModels/Create
    public IActionResult Create()
    {
      ViewData["MachineTypeId"] = new SelectList(_context.MachineType, "MachineTypeId", "Name");
      ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name");
      return View();
    }

    // POST: Equipment/MachineModels/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MachineModelId,ManufacturerId,MachineTypeId,Model")] MachineModel machineModel)
    {
      if (ModelState.IsValid)
      {
        _context.Add(machineModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["MachineTypeId"] = new SelectList(_context.MachineType, "MachineTypeId", "MachineTypeId", machineModel.MachineTypeId);
      ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "ManufacturerId", machineModel.ManufacturerId);
      return View(machineModel);
    }

    // GET: Equipment/MachineModels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var machineModel = await _context.MachineModel.SingleOrDefaultAsync(m => m.MachineModelId == id);
      if (machineModel == null)
      {
        return NotFound();
      }
      ViewData["MachineTypeId"] = new SelectList(_context.MachineType, "MachineTypeId", "Name", machineModel.MachineTypeId);
      ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name", machineModel.ManufacturerId);
      return View(machineModel);
    }

    // POST: Equipment/MachineModels/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("MachineModelId,ManufacturerId,MachineTypeId,Model")] MachineModel machineModel)
    {
      if (id != machineModel.MachineModelId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(machineModel);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MachineModelExists(machineModel.MachineModelId))
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
      ViewData["MachineTypeId"] = new SelectList(_context.MachineType, "MachineTypeId", "Name", machineModel.MachineTypeId);
      ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "Name", machineModel.ManufacturerId);
      return View(machineModel);
    }

    // GET: Equipment/MachineModels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var machineModel = await _context.MachineModel
          .Include(m => m.machineType)
          .Include(m => m.manufacturer)
          .SingleOrDefaultAsync(m => m.MachineModelId == id);
      if (machineModel == null)
      {
        return NotFound();
      }

      return View(machineModel);
    }

    // POST: Equipment/MachineModels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var machineModel = await _context.MachineModel.SingleOrDefaultAsync(m => m.MachineModelId == id);
      _context.MachineModel.Remove(machineModel);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MachineModelExists(int id)
    {
      return _context.MachineModel.Any(e => e.MachineModelId == id);
    }
  }
}
