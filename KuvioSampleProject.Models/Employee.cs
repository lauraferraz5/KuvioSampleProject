using KuvioSampleProject.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KuvioSampleProject.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name must be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name must be provided")]
        [MinLength(2)]
        public string LastName { get; set; } 
        
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "kuviocreative.com", ErrorMessage = "Only kuviocreative.com is allowed")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Country must be provided")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Date of birth must be provided")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}
