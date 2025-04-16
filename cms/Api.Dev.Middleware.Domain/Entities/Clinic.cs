using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Domain.Entities
{
    public class Clinic
    {

        public int ClinicID { get; set; }
        [Required]
        public string ClinicName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MinLength(10)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter valid numeric value.")]
        public string  ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? CreatedDate { get; set; } = null;

      
        public ICollection<Staff> Staff { get; set; }
        public ICollection<Patient> Patients { get; set; }

    }
}
