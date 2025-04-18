using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using Api.Dev.Middleware.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Infrastructure.Repositories
{
 

    public class StaffReppository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public StaffReppository(ApplicationDbContext context
            //,IDbContextFactory<ApplicationDbContext> contextFactory
            )
        {
            _context = context;
            //_contextFactory = contextFactory;
        }


        public async Task<Staff> AddStaffAsync(Staff staff)
        {

                _context.Staff.AddAsync(staff);
                await _context.SaveChangesAsync();

                 return staff;



        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var existingStaff = await _context.Staff.FirstOrDefaultAsync(s => s.StaffID == id);

            if (existingStaff==null)
                return false;

            _context.Staff.Remove(existingStaff);
            await _context.SaveChangesAsync();

             return true;
            
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            //using var context = _contextFactory.CreateDbContext();
            //return await context.Staff.Include(s => s.Clinic).ToListAsync();

            var allStaff = await _context.Staff
        .Include(s => s.Clinic)
        .ToListAsync();
            return allStaff;
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            var getStaff = await _context.Staff.FirstOrDefaultAsync(s => s.StaffID == id);
            if (getStaff == null)
                return null;

            return getStaff;
        }

        public async Task<Staff> GetStaffByNameAsync(string staffName)
        {
            var getStaffByName = await _context.Staff.FirstOrDefaultAsync(s => s.StaffName.Contains(staffName));
            if (getStaffByName == null)
                return null;

            return getStaffByName;
            

        }

        public async Task<bool> UpdateStaffAsync(Staff staff)
        {
           
            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
