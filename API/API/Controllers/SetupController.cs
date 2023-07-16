using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly DataContext _context;

        public SetupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetContacts()
        {
            if (_context.States.Any())
            {
                return BadRequest("Data is already in the system");
            }

            _context.States.AddRange(new List<State>
             {
                    new State(){StateId = 1, Name = "Alabama", Abbreviation = "AL"},
                    new State(){StateId = 2, Name = "Alaska", Abbreviation = "AK"},
                    new State(){StateId = 3, Name = "Arizona", Abbreviation = "AZ"},
                    new State(){StateId = 4, Name = "Arkansas", Abbreviation = "AR"},
                    new State(){StateId = 5, Name = "California", Abbreviation = "CA"},
                    new State(){StateId = 6, Name = "Colorado", Abbreviation = "CO"},
                    new State(){StateId = 7, Name = "Connecticut", Abbreviation = "CT"},
                    new State(){StateId = 8, Name = "Delaware", Abbreviation = "DE"},
                    new State(){StateId = 9, Name = "District Of Columbia", Abbreviation = "DC"},
                    new State(){StateId = 10, Name = "Florida", Abbreviation = "FL"},
                    new State(){StateId = 11, Name = "Georgia", Abbreviation = "GA"},
                    new State(){StateId = 12, Name = "Hawaii", Abbreviation = "HI"},
                    new State(){StateId = 13, Name = "Idaho", Abbreviation = "ID"},
                    new State(){StateId = 14, Name = "Illinois", Abbreviation = "IL"},
                    new State(){StateId = 15, Name = "Indiana", Abbreviation = "IN"},
                    new State(){StateId = 16, Name = "Iowa", Abbreviation = "IA"},
                    new State(){StateId = 17, Name = "Kansas", Abbreviation = "KS"},
                    new State(){StateId = 18, Name = "Kentucky", Abbreviation = "KY"},
                    new State(){StateId = 19, Name = "Louisiana", Abbreviation = "LA"},
                    new State(){StateId = 20, Name = "Maine", Abbreviation = "ME"},
                    new State(){StateId = 21, Name = "Maryland", Abbreviation = "MD"},
                    new State(){StateId = 22, Name = "Massachusetts", Abbreviation = "MA"},
                    new State(){StateId = 23, Name = "Michigan", Abbreviation = "MI"},
                    new State(){StateId = 24, Name = "Minnesota", Abbreviation = "MN"},
                    new State(){StateId = 25, Name = "Mississippi", Abbreviation = "MS"},
                    new State(){StateId = 26, Name = "Missouri", Abbreviation = "MO"},
                    new State(){StateId = 27, Name = "Montana", Abbreviation = "MT"},
                    new State(){StateId = 28, Name = "Nebraska", Abbreviation = "NE"},
                    new State(){StateId = 29, Name = "Nevada", Abbreviation = "NV"},
                    new State(){StateId = 30, Name = "New Hampshire", Abbreviation = "NH"},
                    new State(){StateId = 31, Name = "New Jersey", Abbreviation = "NJ"},
                    new State(){StateId = 32, Name = "New Mexico", Abbreviation = "NM"},
                    new State(){StateId = 33, Name = "New York", Abbreviation = "NY"},
                    new State(){StateId = 34, Name = "North Carolina", Abbreviation = "NC"},
                    new State(){StateId = 35, Name = "North Dakota", Abbreviation = "ND"},
                    new State(){StateId = 36, Name = "Ohio", Abbreviation = "OH"},
                    new State(){StateId = 37, Name = "Oklahoma", Abbreviation = "OK"},
                    new State(){StateId = 38, Name = "Oregon", Abbreviation = "OR"},
                    new State(){StateId = 39, Name = "Pennsylvania", Abbreviation = "PA"},
                    new State(){StateId = 40, Name = "Rhode Island", Abbreviation = "RI"},
                    new State(){StateId = 41, Name = "South Carolina", Abbreviation = "SC"},
                    new State(){StateId = 42, Name = "South Dakota", Abbreviation = "SD"},
                    new State(){StateId = 43, Name = "Tennessee", Abbreviation = "TN"},
                    new State(){StateId = 44, Name = "Texas", Abbreviation = "TX"},
                    new State(){StateId = 45, Name = "Utah", Abbreviation = "UT"},
                    new State(){StateId = 46, Name = "Vermont", Abbreviation = "VT"},
                    new State(){StateId = 47, Name = "Virginia", Abbreviation = "VA"},
                    new State(){StateId = 48, Name = "Washington", Abbreviation = "WA"},
                    new State(){StateId = 49, Name = "West Virginia", Abbreviation = "WV"},
                    new State(){StateId = 50, Name = "Wisconsin", Abbreviation = "WI"},
                    new State(){StateId = 51, Name = "Wyoming", Abbreviation = "WY"},
             });
            _context.SaveChanges();

            _context.ContactFrequencies.AddRange(new List<ContactFrequency>
            {
                new ContactFrequency { ContactFrequencyId = 1, Name = "Only Account Information", Description = "Contact only about account Information" },
                new ContactFrequency { ContactFrequencyId = 2, Name = "Marketing Information", Description = "Ok to contact with marketing Information" },
                new ContactFrequency { ContactFrequencyId = 3, Name = "Third Party Marketing Information", Description = "Ok to contact with third-party marketing information" },
            });
            _context.SaveChanges();

            _context.ContactMethods.AddRange(new List<ContactMethod>
            {
                new ContactMethod {ContactMethodId=1,Description="Text"},
                new ContactMethod {ContactMethodId=2,Description="Email"},
                new ContactMethod {ContactMethodId=3,Description="Phone"}
            });
            _context.SaveChanges();

            _context.Contacts.Add(new Contact
            {
                FirstName = "Philip",
                LastName = "Smith",
                Email = "trumpet7347@gmail.com",
                Street = "2201 Houstonia Dr",
                City = "Knoxville",
                State = _context.States.FirstOrDefault(s => s.Abbreviation == "TN"),
                Zip = "37918",
                PhoneNumber = "6015195402",
                ContactFrequency = _context.ContactFrequencies.FirstOrDefault(cf => cf.ContactFrequencyId == 1),
                ContactMethod = _context.ContactMethods.FirstOrDefault(cm => cm.ContactMethodId == 3)
            });

            _context.SaveChanges();
            return Ok("Test Data Setup");
        }
    }
}