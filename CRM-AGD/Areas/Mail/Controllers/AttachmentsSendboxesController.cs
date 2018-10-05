using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_AGD.Areas.Mail.Models;
using CRM_AGD.Data;

namespace CRM_AGD.Areas.Mail.Controllers
{
    [Produces("application/json")]
    [Route("api/AttachmentsSendboxes")]
    public class AttachmentsSendboxesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttachmentsSendboxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AttachmentsSendboxes
        [HttpGet]
        public IEnumerable<AttachmentsSendbox> GetAttachmentsSendbox()
        {
            return _context.AttachmentsSendbox;
        }

        // GET: api/AttachmentsSendboxes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttachmentsSendbox([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attachmentsSendbox = await _context.AttachmentsSendbox.SingleOrDefaultAsync(m => m.AttachmentsSendboxId == id);

            if (attachmentsSendbox == null)
            {
                return NotFound();
            }

            return Ok(attachmentsSendbox);
        }

        // PUT: api/AttachmentsSendboxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttachmentsSendbox([FromRoute] int id, [FromBody] AttachmentsSendbox attachmentsSendbox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attachmentsSendbox.AttachmentsSendboxId)
            {
                return BadRequest();
            }

            _context.Entry(attachmentsSendbox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentsSendboxExists(id))
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

        // POST: api/AttachmentsSendboxes
        [HttpPost]
        public async Task<IActionResult> PostAttachmentsSendbox([FromBody] AttachmentsSendbox attachmentsSendbox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AttachmentsSendbox.Add(attachmentsSendbox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttachmentsSendbox", new { id = attachmentsSendbox.AttachmentsSendboxId }, attachmentsSendbox);
        }

        // DELETE: api/AttachmentsSendboxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachmentsSendbox([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attachmentsSendbox = await _context.AttachmentsSendbox.SingleOrDefaultAsync(m => m.AttachmentsSendboxId == id);
            if (attachmentsSendbox == null)
            {
                return NotFound();
            }

            _context.AttachmentsSendbox.Remove(attachmentsSendbox);
            await _context.SaveChangesAsync();

            return Ok(attachmentsSendbox);
        }

        private bool AttachmentsSendboxExists(int id)
        {
            return _context.AttachmentsSendbox.Any(e => e.AttachmentsSendboxId == id);
        }
    }
}