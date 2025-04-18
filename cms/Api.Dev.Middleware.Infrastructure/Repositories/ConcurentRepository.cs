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
    class ConcurentRepository : IConcurentRepository
    {
        private readonly ApplicationDbContext _contextFactory;

        public ConcurentRepository(ApplicationDbContext contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Clinic>> GeatAllClinicAsync()
        {
            //using var context = _contextFactory.CreateDbContext();
            return await _contextFactory.Clinics.ToListAsync();

        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            //using var context = _contextFactory.CreateDbContext();
            return await _contextFactory.Patients.Include(p => p.Clinic).ToListAsync();
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            //using var context = _contextFactory.CreateDbContext();
            return await _contextFactory.Staff.Include(s => s.Clinic).ToListAsync();

        }
    }
}
