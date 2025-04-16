using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Dtos.ClinicDto
{
    public class ClinicDto
    {
        public int? ClinicID { get; set; }
        [Required]
        [StringLength(50)]
        public string ClinicName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MinLength(10)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter valid numeric value.")]
        public string ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Website { get; set; }

        //public ICollection<Staff> Staffs { get; set; }


    }
}
