using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Domain.Interfaces
{
   public interface IPatientRepository
    {

        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientAsync(int id);
        Task<bool> GetPatientByNameAsync(string name);
        Task<Patient> GetPatientByIdAsync(int id);

    }
}
