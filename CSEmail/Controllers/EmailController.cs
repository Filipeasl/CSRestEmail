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

        private bool EmailMsgExists(long id)
        {
            return _context.EmailMsg.Any(e => e.Id == id);
        }
    }
}
