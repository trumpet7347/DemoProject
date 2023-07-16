using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _context.Contacts
                .Include(c => c.State)
                .Include(c => c.ContactFrequency)
                .Include(c => c.ContactMethod)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact =  _context.Contacts
                .Include(c => c.State)
                .Include(c => c.ContactFrequency)
                .Include(c => c.ContactMethod)
                .FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPut]
        public async Task<IActionResult> PutContact(Contact contact)
        {
            if (!UpdateContactRelationalObjects(contact, out var message))
            {
                return BadRequest(message);
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.ContactId))
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

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            if (!UpdateContactRelationalObjects(contact, out var message))
            {
                return BadRequest(message);
            }

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.ContactId }, contact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactId == id);
        }

        private bool UpdateContactRelationalObjects(Contact contact, out string errorMessage)
        {
            var state = _context.States.FirstOrDefault(s => s.StateId == contact.State.StateId);
            var frequency = _context.ContactFrequencies.FirstOrDefault(f =>
                f.ContactFrequencyId == contact.ContactFrequency.ContactFrequencyId);
            var method =
                _context.ContactMethods.FirstOrDefault(m => m.ContactMethodId == contact.ContactMethod.ContactMethodId);

            if (state == null)
            {
                errorMessage = "State does not exist";
                return false;
            }

            if (frequency == null)
            {
                errorMessage = "Contact Frequency does not exist";
                return false;
            }

            if (method == null)
            {
                errorMessage = "Contact Method does not exist";
                return false;
            }

            contact.State = state;
            contact.ContactFrequency = frequency;
            contact.ContactMethod = method;

            errorMessage = null;
            return true;
        }
    }
}
