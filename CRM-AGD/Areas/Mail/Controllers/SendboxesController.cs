using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Mail.Models;
using CRM_AGD.Data;

namespace CRM_AGD.Areas.Mail.Controllers
{
    [Area("Mail")]
    public class SendboxesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendboxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mail/Sendboxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sendbox.ToListAsync());
        }

        // GET: Mail/Sendboxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendbox = await _context.Sendbox
                .SingleOrDefaultAsync(m => m.SendboxId == id);
            if (sendbox == null)
            {
                return NotFound();
            }

            return View(sendbox);
        }

        // GET: Mail/Sendboxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mail/Sendboxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SendboxId,MailFrom,MailTo,Date,Tittle,Message,MessageHtml")] Sendbox sendbox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sendbox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sendbox);
        }

        // GET: Mail/Sendboxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendbox = await _context.Sendbox.SingleOrDefaultAsync(m => m.SendboxId == id);
            if (sendbox == null)
            {
                return NotFound();
            }
            return View(sendbox);
        }

        // POST: Mail/Sendboxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SendboxId,MailFrom,MailTo,Date,Tittle,Message,MessageHtml")] Sendbox sendbox)
        {
            if (id != sendbox.SendboxId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sendbox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SendboxExists(sendbox.SendboxId))
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
            return View(sendbox);
        }

        // GET: Mail/Sendboxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sendbox = await _context.Sendbox
                .SingleOrDefaultAsync(m => m.SendboxId == id);
            if (sendbox == null)
            {
                return NotFound();
            }

            return View(sendbox);
        }

        // POST: Mail/Sendboxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sendbox = await _context.Sendbox.SingleOrDefaultAsync(m => m.SendboxId == id);
            _context.Sendbox.Remove(sendbox);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SendboxExists(int id)
        {
            return _context.Sendbox.Any(e => e.SendboxId == id);
        }
    }
}
