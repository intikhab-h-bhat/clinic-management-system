using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Interfaces
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicDto>>  GetAllClinicsAsync();
        Task<ClinicDto> AddClinicAsync(ClinicDto clinicDto);
        Task<ClinicDto> GetClinicByIdAsync(int id);
        Task<ClinicDto> GetClinicByNameAsync(string clinicName);

        Task<bool> DeleteClinicAsync(int id);

        Task<ClinicDto> UpdateClinicAsync(int id, ClinicDto clinicDto);

    }
}
