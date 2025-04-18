using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Domain.Interfaces
{
    public interface IConcurentRepository
    {
        Task<IEnumerable<Clinic>> GeatAllClinicAsync();
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<IEnumerable<Staff>> GetAllStaffAsync();
    }
}
