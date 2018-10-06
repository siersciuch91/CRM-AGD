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
  public class IssuesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public IssuesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Client/Issues
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.Issue.Include(i => i.client).Include(i => i.machineModel);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Client/Issues/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var issue = await _context.Issue
          .Include(i => i.client)
          .Include(i => i.machineModel)
          .SingleOrDefaultAsync(m => m.IssueId == id);
      if (issue == null)
      {
        return NotFound();
      }

      return View(issue);
    }

    // GET: Client/Issues/Create
    public IActionResult Create()
    {
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress");
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model");
      return View();
    }

    // POST: Client/Issues/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IssueId,ClientId,MachineModelId,Term,Description")] Issue issue)
    {
      if (ModelState.IsValid)
      {
        _context.Add(issue);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress", issue.ClientId);
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model", issue.MachineModelId);
      return View(issue);
    }

    // GET: Client/Issues/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var issue = await _context.Issue.SingleOrDefaultAsync(m => m.IssueId == id);
      if (issue == null)
      {
        return NotFound();
      }
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress", issue.ClientId);
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model", issue.MachineModelId);
      return View(issue);
    }

    // POST: Client/Issues/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IssueId,ClientId,MachineModelId,Term,Description")] Issue issue)
    {
      if (id != issue.IssueId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(issue);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!IssueExists(issue.IssueId))
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
      ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "EmailAddress", issue.ClientId);
      ViewData["MachineModelId"] = new SelectList(_context.MachineModel, "MachineModelId", "Model", issue.MachineModelId);
      return View(issue);
    }

    // GET: Client/Issues/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var issue = await _context.Issue
          .Include(i => i.client)
          .Include(i => i.machineModel)
          .SingleOrDefaultAsync(m => m.IssueId == id);
      if (issue == null)
      {
        return NotFound();
      }

      return View(issue);
    }

    // POST: Client/Issues/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var issue = await _context.Issue.SingleOrDefaultAsync(m => m.IssueId == id);
      _context.Issue.Remove(issue);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool IssueExists(int id)
    {
      return _context.Issue.Any(e => e.IssueId == id);
    }
  }
}
