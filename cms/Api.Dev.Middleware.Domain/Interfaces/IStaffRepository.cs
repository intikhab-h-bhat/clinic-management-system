using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Domain.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff> AddStaffAsync(Staff staff);
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task<Staff> GetStaffByNameAsync(string staffName);
        Task<bool> UpdateStaffAsync(Staff staff);

        Task<bool> DeleteStaffAsync(int id);

    }
}
