using Api.Dev.Middleware.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Dev.Middleware.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        // You can add custom fields here if needed, e.g., link to Clinic or Staff
       public string FullName { get; set; }
        public int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
    }
}
