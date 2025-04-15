using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Dtos.StaffDto
{
    public class StaffDto
    {
        public int StaffID { get; set; }
        public int ClinicID { get; set; }
          public string StaffName { get; set; }
          public string ContactNumber { get; set; }
          public string Email { get; set; }
         public string DateOfJoining { get; set; }
     
        //public Clinic Clinic { get; set; } // Navigation property
    }
}
