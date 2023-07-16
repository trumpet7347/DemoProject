using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string Street { get; set; }

        [MaxLength(50)]
        [Required]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [MaxLength(20)]
        [Required]
        public string Zip { get; set; }

        [MaxLength(10)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public ContactFrequency ContactFrequency { get; set; }

        [Required]
        public ContactMethod ContactMethod { get; set; }
    }

}
