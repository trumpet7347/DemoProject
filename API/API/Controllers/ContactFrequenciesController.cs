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
    public class ContactFrequenciesController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactFrequenciesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactFrequency>>> GetContactFrequencies()
        {
            return await _context.ContactFrequencies.ToListAsync();
        }
    }
}
