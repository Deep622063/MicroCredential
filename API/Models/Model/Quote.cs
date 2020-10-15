using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Model
{
    public class Quote : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime Startdate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal ContributionAmount { get; set; }

        public double MaturityAmount { get; set; }

        public Customer Customer { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (Startdate >= EndDate)
            {
                yield return new ValidationResult("Start should be before End date");
            }
        }
    }
}
