using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Client.Models;
using CRM_AGD.Data;
using Microsoft.AspNetCore.Authorization;

namespace CRM_AGD.Areas.Client.Controllers
{
  [Area("Client")]
  [Authorize]
  public class IssueFromPortalsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public IssueFromPortalsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Client/IssueFromPortals
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.IssueFromPortal.Include(i => i.machineModel).Include(i => i.street);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Client/IssueFromPortals/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var issueFromPortal = await _context.IssueFromPortal
          .Include(i => i.machineModel)
          .Include(i => i.street)
          .SingleOrDefaultAsync(m => m.IssueFromPortalId == id);
      if (issueFromPortal == null)
      {
        return NotFound();
      }

      return View(issueFromPortal);
    }

    // GET: Client/IssueFromPortals/Create
    public IActionResult Create()
    {
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model");
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "Name");
      return View();
    }

    // POST: Client/IssueFromPortals/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IssueFromPortalId,MachineModelId,FirstName,SecondName,EmailAddress,PhoneNumber,StreetId,HomeNumber,SuggestedDate,Description")] IssueFromPortal issueFromPortal)
    {
      if (ModelState.IsValid)
      {
        _context.Add(issueFromPortal);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model", issueFromPortal.MachineModelId);
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "Name", issueFromPortal.StreetId);
      return View(issueFromPortal);
    }

    // GET: Client/IssueFromPortals/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var issueFromPortal = await _context.IssueFromPortal.SingleOrDefaultAsync(m => m.IssueFromPortalId == id);
      if (issueFromPortal == null)
      {
        return NotFound();
      }
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model", issueFromPortal.MachineModelId);
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "Name", issueFromPortal.StreetId);
      return View(issueFromPortal);
    }

    // POST: Client/IssueFromPortals/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IssueFromPortalId,MachineModelId,FirstName,SecondName,EmailAddress,PhoneNumber,StreetId,HomeNumber,SuggestedDate,Description")] IssueFromPortal issueFromPortal)
    {
      if (id != issueFromPortal.IssueFromPortalId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(issueFromPortal);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!IssueFromPortalExists(issueFromPortal.IssueFromPortalId))
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
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model", issueFromPortal.MachineModelId);
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "Name", issueFromPortal.StreetId);
      return View(issueFromPortal);
    }

    // GET: Client/IssueFromPortals/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var issueFromPortal = await _context.IssueFromPortal
          .Include(i => i.machineModel)
          .Include(i => i.street)
          .SingleOrDefaultAsync(m => m.IssueFromPortalId == id);
      if (issueFromPortal == null)
      {
        return NotFound();
      }

      return View(issueFromPortal);
    }

    // POST: Client/IssueFromPortals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var issueFromPortal = await _context.IssueFromPortal.SingleOrDefaultAsync(m => m.IssueFromPortalId == id);
      _context.IssueFromPortal.Remove(issueFromPortal);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool IssueFromPortalExists(int id)
    {
      return _context.IssueFromPortal.Any(e => e.IssueFromPortalId == id);
    }
  }
}
