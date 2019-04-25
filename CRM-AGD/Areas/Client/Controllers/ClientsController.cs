using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Data;
using Microsoft.AspNetCore.Authorization;

namespace CRM_AGD.Areas.Client.Controllers
{
    [Area("Client")]
  [Authorize]
  public class ClientsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ClientsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Client/Clients
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.Client.Include(c => c.street).Include(c => c.street.streetPrefix).Include(c => c.street.city);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Client/Clients/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var client = await _context.Client.Include(c => c.street).Include(c => c.street.streetPrefix).Include(c => c.street.city)
          .SingleOrDefaultAsync(m => m.ClientId == id);
      if (client == null)
      {
        return NotFound();
      }

      return View(client);
    }

    // GET: Client/Clients/Create
    public IActionResult Create()
    {
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "StreetId");
      return View();
    }

    // POST: Client/Clients/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ClientId,FirstName,SecondName,EmailAddress,PhoneNumber,StreetId,HomeNumber")] CRM_AGD.Areas.Client.Models.Client client)
    {
      if (ModelState.IsValid)
      {
        _context.Add(client);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "StreetId", client.StreetId);
      return View(client);
    }

    // GET: Client/Clients/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var client = await _context.Client.SingleOrDefaultAsync(m => m.ClientId == id);
      if (client == null)
      {
        return NotFound();
      }
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "StreetId", client.StreetId);
      return View(client);
    }

    // POST: Client/Clients/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ClientId,FirstName,SecondName,EmailAddress,PhoneNumber,StreetId,HomeNumber")] CRM_AGD.Areas.Client.Models.Client client)
    {
      if (id != client.ClientId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(client);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ClientExists(client.ClientId))
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
      ViewData["StreetId"] = new SelectList(_context.Streets, "StreetId", "StreetId", client.StreetId);
      return View(client);
    }

    // GET: Client/Clients/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var client = await _context.Client
          .Include(c => c.street)
          .SingleOrDefaultAsync(m => m.ClientId == id);
      if (client == null)
      {
        return NotFound();
      }

      return View(client);
    }

    // POST: Client/Clients/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var client = await _context.Client.SingleOrDefaultAsync(m => m.ClientId == id);
      _context.Client.Remove(client);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ClientExists(int id)
    {
      return _context.Client.Any(e => e.ClientId == id);
    }
  }
}
