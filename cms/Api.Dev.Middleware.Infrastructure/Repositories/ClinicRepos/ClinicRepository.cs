using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using Api.Dev.Middleware.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Dev.Middleware.Infrastructure.Repositories.ClinicRepos

{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ApplicationDbContext _context;
        public ClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<Clinic> AddClinicAsync(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();

            return clinic;

        }

        public async Task<bool> DeleteClinicAsync(int id)
        {
            var getClinic = await _context.Clinics.FirstOrDefaultAsync(c => c.ClinicID == id);
            if (getClinic == null)
                return false;

            _context.Clinics.Remove(getClinic);
            await _context.SaveChangesAsync();

            return true;
           
        }

        public async Task<IEnumerable<Clinic>> GeatAllClinicAsync()
        {
            var allClinics = await _context.Clinics.ToListAsync();
            //var allClinics = await _context.Clinics.Include(c => c.Staff).ToListAsync();

            return allClinics;
        }

        public async Task<Clinic> GetClinicByIdAsync(int id)
        {
            var getClinicById = await _context.Clinics.FirstOrDefaultAsync(c=> c.ClinicID==id);

            if (getClinicById == null)
                return null;

            return getClinicById;
        }

        public async Task<Clinic> GetClinicByNameAsync(string clinicName)
        {
            var getClinicByName = await _context.Clinics.FirstOrDefaultAsync(c => c.ClinicName.Contains(clinicName));

            if (getClinicByName == null)
                return null;


            return getClinicByName;

        }
              

        public async Task<Clinic> UpdateClinicAsync(int id, Clinic clinic)
        {
             _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();

            return clinic; 

        }
    }
}
