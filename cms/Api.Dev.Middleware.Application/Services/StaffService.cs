using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {

            _staffRepository = staffRepository;

        }



        public async Task<StaffDto> AddStaffAsync(StaffDto staffDto)
        {
            var addStaff = new Staff
            {
                StaffName = staffDto.StaffName,
                ClinicID = staffDto.ClinicID,
               ContactNumber = staffDto.ContactNumber,
                Email = staffDto.Email,
               
                DateOfJoining=staffDto.DateOfJoining,
                

            };


             await _staffRepository.AddStaffAsync(addStaff);


            return staffDto;


        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var deleteStaff = await _staffRepository.DeleteStaffAsync(id);

            if (!deleteStaff)
                return false;
            return true;
        }

        public async Task<IEnumerable<GetStaffDto>> GetAllStaffAsync()
        {
            var allStaff = await _staffRepository.GetAllStaffAsync();

            var allStaffDto = allStaff.Select(s => new GetStaffDto
            {
                StaffID=s.StaffID,
                StaffName = s.StaffName,
                ClinicID=s.ClinicID,
               ClinicName=s.Clinic.ClinicName,
                ContactNumber=s.ContactNumber,
                Email=s.Email,
                DateOfJoining=s.DateOfJoining
            });

            return allStaffDto;
        }

        public async Task<StaffDto> GetStaffByIdAsync(int id)
        {
            var getStaff = await _staffRepository.GetStaffByIdAsync(id);

            if (getStaff == null)
                return null;

            var getStaffDto = new StaffDto()
            {
                StaffID=getStaff.StaffID,
                StaffName = getStaff.StaffName,
                ClinicID = getStaff.ClinicID,
                ContactNumber = getStaff.ContactNumber,
                Email = getStaff.Email,
            };

            return getStaffDto;
        }

        public async Task<StaffDto> GetStaffByNameAsync(string staffName)
        {
            var getStaffByName = await _staffRepository.GetStaffByNameAsync(staffName);

            if (getStaffByName == null)
                return null;

            var getStaffDto = new StaffDto
            {
                StaffID = getStaffByName.StaffID,
                StaffName=getStaffByName.StaffName,
                ClinicID = getStaffByName.ClinicID,
                ContactNumber = getStaffByName.ContactNumber,
                Email = getStaffByName.Email,


            };

            return getStaffDto;
        }

        public async Task<bool> UpdateStaffAsync(int id, StaffDto staffDto)
        {
            var existingStaff = await _staffRepository.GetStaffByIdAsync(id);

            if (existingStaff == null)
                return false;

            existingStaff.StaffName = staffDto.StaffName;
            existingStaff.ClinicID = staffDto.ClinicID;
            existingStaff.ContactNumber = staffDto.ContactNumber;
            existingStaff.Email = staffDto.Email;
            existingStaff.DateOfJoining = staffDto.DateOfJoining;


            var updateStaff = await _staffRepository.UpdateStaffAsync(existingStaff);
            
            if (updateStaff == null)
                    return false;


            return true;



        }
    }
}
