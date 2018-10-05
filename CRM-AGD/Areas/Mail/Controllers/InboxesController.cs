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
    public class InboxesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InboxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mail/Inboxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inbox.ToListAsync());
        }

        // GET: Mail/Inboxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inbox = await _context.Inbox
                .SingleOrDefaultAsync(m => m.InboxId == id);
            if (inbox == null)
            {
                return NotFound();
            }

            return View(inbox);
        }

        // GET: Mail/Inboxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mail/Inboxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InboxId,MailFrom,MailTo,Date,Tittle,Message,MessageHtml")] Inbox inbox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inbox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inbox);
        }

        // GET: Mail/Inboxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inbox = await _context.Inbox.SingleOrDefaultAsync(m => m.InboxId == id);
            if (inbox == null)
            {
                return NotFound();
            }
            return View(inbox);
        }

        // POST: Mail/Inboxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InboxId,MailFrom,MailTo,Date,Tittle,Message,MessageHtml")] Inbox inbox)
        {
            if (id != inbox.InboxId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inbox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InboxExists(inbox.InboxId))
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
            return View(inbox);
        }

        // GET: Mail/Inboxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inbox = await _context.Inbox
                .SingleOrDefaultAsync(m => m.InboxId == id);
            if (inbox == null)
            {
                return NotFound();
            }

            return View(inbox);
        }

        // POST: Mail/Inboxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inbox = await _context.Inbox.SingleOrDefaultAsync(m => m.InboxId == id);
            _context.Inbox.Remove(inbox);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InboxExists(int id)
        {
            return _context.Inbox.Any(e => e.InboxId == id);
        }
    }
}
