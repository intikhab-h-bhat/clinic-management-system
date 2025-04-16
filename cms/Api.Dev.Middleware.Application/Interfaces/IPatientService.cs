using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> AddPatientAsync(PatientDto patient);
        Task<PatientDto> UpdatePatientAsync(int id,PatientDto patient);
        Task<bool> DeletePatientAsync(int id);
        Task<bool> GetPatientByNameAsync(string name);
        Task<PatientDto> GetPatientByIdAsync(int id);

    }
}
