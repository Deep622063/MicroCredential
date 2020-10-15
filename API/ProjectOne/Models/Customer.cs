using ProjectOne.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(15)]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBith { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        public string PermanentAccountNumber { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required, RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")]
        public string EmailAddress { get; set; }

        [Required]
        public string Line1 { get; set; }

        [Required]
        public string Line2 { get; set; }

        [Required]
        public string Line3 { get; set; }

        public string Line4 { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public Country Country { get; set; }
    }
}
