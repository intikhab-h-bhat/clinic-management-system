using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Domain.Interfaces
{
    public interface IClinicRepository
    {

        Task<IEnumerable<Clinic>> GeatAllClinicAsync();

        Task<Clinic> AddClinicAsync(Clinic clinic);

        Task<Clinic> GetClinicByIdAsync(int id);
        Task<Clinic> GetClinicByNameAsync(string clinicName);

        Task<bool> DeleteClinicAsync(int id);

        Task<Clinic> UpdateClinicAsync(int id, Clinic clinic);

        

    }
}
