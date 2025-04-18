using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Dtos.StaffDto;

namespace Api.Dev.Middleware.Application.Interfaces
{
    public interface IConcurentService
    {
        Task<IEnumerable<ClinicDto>> GeatAllClinicAsync();
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<IEnumerable<GetStaffDto>> GetAllStaffAsync();
    }
}
