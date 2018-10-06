using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Mail.Models;
using CRM_AGD.Data;
using Microsoft.AspNetCore.Authorization;

namespace CRM_AGD.Areas.Mail.Controllers
{
  [Produces("application/json")]
  [Route("api/AttachmentsInboxes")]
  [Authorize]
  public class AttachmentsInboxesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public AttachmentsInboxesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: api/AttachmentsInboxes
    [HttpGet]
    public IEnumerable<AttachmentsInbox> GetAttachmentsInbox()
    {
      return _context.AttachmentsInbox;
    }

    // GET: api/AttachmentsInboxes/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAttachmentsInbox([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var attachmentsInbox = await _context.AttachmentsInbox.SingleOrDefaultAsync(m => m.AttachmentsInboxId == id);

      if (attachmentsInbox == null)
      {
        return NotFound();
      }

      return Ok(attachmentsInbox);
    }

    // PUT: api/AttachmentsInboxes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAttachmentsInbox([FromRoute] int id, [FromBody] AttachmentsInbox attachmentsInbox)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != attachmentsInbox.AttachmentsInboxId)
      {
        return BadRequest();
      }

      _context.Entry(attachmentsInbox).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AttachmentsInboxExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/AttachmentsInboxes
    [HttpPost]
    public async Task<IActionResult> PostAttachmentsInbox([FromBody] AttachmentsInbox attachmentsInbox)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.AttachmentsInbox.Add(attachmentsInbox);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetAttachmentsInbox", new { id = attachmentsInbox.AttachmentsInboxId }, attachmentsInbox);
    }

    // DELETE: api/AttachmentsInboxes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttachmentsInbox([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var attachmentsInbox = await _context.AttachmentsInbox.SingleOrDefaultAsync(m => m.AttachmentsInboxId == id);
      if (attachmentsInbox == null)
      {
        return NotFound();
      }

      _context.AttachmentsInbox.Remove(attachmentsInbox);
      await _context.SaveChangesAsync();

      return Ok(attachmentsInbox);
    }

    private bool AttachmentsInboxExists(int id)
    {
      return _context.AttachmentsInbox.Any(e => e.AttachmentsInboxId == id);
    }
  }
}