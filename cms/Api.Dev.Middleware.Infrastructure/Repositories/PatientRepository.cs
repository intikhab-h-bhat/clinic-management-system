using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using Api.Dev.Middleware.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;   
        }


        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (existingPatient == null)
                return false;
            _context.Patients.Remove(existingPatient);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            var allPatients = await _context.Patients.Include(p => p.Clinic)
                .ToListAsync();

            return allPatients;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
                return null;

            return patient;

        }

        public async Task<bool> GetPatientByNameAsync(string name)
        {
            var patientName = await _context.Patients.FirstOrDefaultAsync(p => p.Name.Contains(name));
            if (patientName == null)
                return false;

            return true;
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
    }
}
