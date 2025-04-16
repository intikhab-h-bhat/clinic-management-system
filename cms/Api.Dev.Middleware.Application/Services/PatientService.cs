using Api.Dev.Middleware.Application.Dtos;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        public async Task<PatientDto> AddPatientAsync(PatientDto patient)
        {
            var newPatient = new Patient
            {
                Name=patient.Name,
                DateOfBirth=patient.DateOfBirth,
                Gender=patient.Gender,
                ContactNumber=patient.ContactNumber,
                Email=patient.Email,
                Address=patient.Address,
                ClinicId=patient.ClinicId       
            };
             
            await _patientRepository.AddPatientAsync(newPatient);

            return patient;

            
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var delPatient = await _patientRepository.DeletePatientAsync(id);
            return delPatient;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var allPatients = await _patientRepository.GetAllPatientsAsync();

            var allPatientsDto = allPatients.Select(p => new PatientDto
            {
                Id=p.Id,
                Name=p.Name,
                DateOfBirth=p.DateOfBirth,
                Gender=p.Gender,
                Email=p.Email,
                Address=p.Address,
                ContactNumber=p.ContactNumber,
                ClinicId=p.ClinicId,
                ClinicName=p.Clinic.ClinicName


            });

            return allPatientsDto;
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
                return null;

            var getPatientDto = new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                ContactNumber = patient.ContactNumber,
                Address = patient.Address,
                Email = patient.Email,
                ClinicName = patient.Clinic.ClinicName,

            };

            return getPatientDto;
        }

        public async Task<bool> GetPatientByNameAsync(string name)
        {
            var patient = await _patientRepository.GetPatientByNameAsync(name);


            return patient;

        }

        public async Task<PatientDto> UpdatePatientAsync(int id ,PatientDto patient)
        {
            var existingPatient = await _patientRepository.GetPatientByIdAsync(id);

            if (existingPatient==null)
                return null;

            existingPatient.Name = patient.Name;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Email = patient.Email;
            existingPatient.Address = patient.Address;
            existingPatient.ContactNumber = patient.ContactNumber;
            existingPatient.Gender = patient.Gender;
            existingPatient.ClinicId = patient.ClinicId;

           var updatePatient= await _patientRepository.UpdatePatientAsync(existingPatient);

            if (updatePatient == null)
                return null;

            return patient;

        }
    }
}
