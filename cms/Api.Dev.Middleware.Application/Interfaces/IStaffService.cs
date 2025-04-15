using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Interfaces
{
   public interface IStaffService
    {

        Task<StaffDto> AddStaffAsync(StaffDto staffDto);        
        Task<IEnumerable<GetStaffDto>> GetAllStaffAsync();
        Task<StaffDto> GetStaffByIdAsync(int id);
        Task<StaffDto> GetStaffByNameAsync(string staffName);
        Task<bool> UpdateStaffAsync(int id,StaffDto staffDto);

        Task<bool> DeleteStaffAsync(int id);

    }
}
