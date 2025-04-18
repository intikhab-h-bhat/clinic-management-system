using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Services
{

    class ConcurentService : IConcurentService
    {

        private readonly IConcurentRepository _concurrentRepository;
        public ConcurentService(IConcurentRepository concurrentRepository)
        {
            _concurrentRepository = concurrentRepository;
        }

        public async Task<IEnumerable<ClinicDto>> GeatAllClinicAsync()
        {
            var allClinics = await _concurrentRepository.GeatAllClinicAsync();
            var allClinicsDto = allClinics.Select(c => new ClinicDto
            {
                ClinicID = c.ClinicID,
                ClinicName = c.ClinicName,
                Address = c.Address,
                ContactNumber = c.ContactNumber,
                Email = c.Email,
                Website = c.Website,
            });

            return allClinicsDto;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var allPatients = await _concurrentRepository.GetAllPatientsAsync();

            var allPatientsDto = allPatients.Select(p => new PatientDto
            {
                Id = p.Id,
                Name = p.Name,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                Email = p.Email,
                Address = p.Address,
                ContactNumber = p.ContactNumber,
                ClinicId = p.ClinicId,
                ClinicName = p.Clinic.ClinicName


            });

            return allPatientsDto;
        }

        public async Task<IEnumerable<GetStaffDto>> GetAllStaffAsync()
        {
            var allStaff = await _concurrentRepository.GetAllStaffAsync();

            var allStaffDto = allStaff.Select(s => new GetStaffDto
            {
                StaffID = s.StaffID,
                StaffName = s.StaffName,
                ClinicID = s.ClinicID,
                ClinicName = s.Clinic.ClinicName,
                ContactNumber = s.ContactNumber,
                Email = s.Email,
                DateOfJoining = s.DateOfJoining
            });

            return allStaffDto;

        }
    }
}
