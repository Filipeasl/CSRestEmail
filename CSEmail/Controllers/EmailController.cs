using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using FluentEmail.Smtp;
using System.Net.Mail;
using FluentEmail.Core;
using System.Net;

namespace CSRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly TodoContext _context;

        public EmailController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Email
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailMsg>>> GetEmailMsg()
        {
            return await _context.EmailMsg.ToListAsync();
        }

        // GET: api/Email/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailMsg>> GetEmailMsg(long id)
        {
            var emailMsg = await _context.EmailMsg.FindAsync(id);

            if (emailMsg == null)
            {
                return NotFound();
            }

            return emailMsg;
        }

        // PUT: api/Email/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailMsg(long id, EmailMsg emailMsg)
        {
            if (id != emailMsg.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailMsg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailMsgExists(id))
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

        // POST: api/Email
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmailMsg>> PostEmailMsg(EmailMsg emailMsg)
        {
            var sender = new SmtpSender(() => new SmtpClient(host:emailMsg.eSmtpHost)
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(emailMsg.eLogin, emailMsg.ePassword),
                EnableSsl = true,
            });

            Email.DefaultSender = sender;

            var email = await Email
            .From(emailMsg.eLogin, emailMsg.eName)
            .To(emailMsg.eTo)
            .Subject(emailMsg.eSubject)
            .Body(emailMsg.eBody)
            .SendAsync();

            _context.EmailMsg.Add(emailMsg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailMsg", new { id = emailMsg.Id }, emailMsg);
        }

        // DELETE: api/Email/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailMsg(long id)
        {
            var emailMsg = await _context.EmailMsg.FindAsync(id);
            if (emailMsg == null)
            {
                return NotFound();
            }

            _context.EmailMsg.Remove(emailMsg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailMsgExists(long id)
        {
            return _context.EmailMsg.Any(e => e.Id == id);
        }
    }
}
