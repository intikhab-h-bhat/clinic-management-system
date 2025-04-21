using Api.Dev.Middleware.Application.Dtos.StaffDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Domain.Entities;
using Api.Dev.Middleware.Domain.Interfaces;

namespace Api.Dev.Middleware.Application.Services
{
    public class StaffService : IStaffService
    {
         private readonly IStaffRepository _staffRepositoryAll;
        private readonly IRepository<Staff> _staffRepository;
        public StaffService(IRepository<Staff> staffRepository, IStaffRepository staffRepositoryAll)
        {

            _staffRepository = staffRepository;
            _staffRepositoryAll = staffRepositoryAll;

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


            //await _staffRepository.AddStaffAsync(addStaff);
            await _staffRepository.AddAsync(addStaff);


            return staffDto;


        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            //var deleteStaff = await _staffRepository.DeleteStaffAsync(id);
            var existingStaff = await _staffRepository.GetByIdAsync(id);
            if (existingStaff == null)
                return false;

            var deleteStaff = await _staffRepository.DeleteAsync(existingStaff);

            if (deleteStaff==0)
                return false;
            return true;
        }

        public async Task<IEnumerable<GetStaffDto>> GetAllStaffAsync()
        {
            var allStaff = await _staffRepositoryAll.GetAllStaffAsync();
            //var allStaff = await _staffRepository.GeatAllAsync();

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
            //var getStaff = await _staffRepository.GetStaffByIdAsync(id);
            var getStaff = await _staffRepository.GetByIdAsync(id);

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
            //var getStaffByName = await _staffRepository.GetStaffByNameAsync(staffName);
            var getStaffByName = await _staffRepository.GetByNameAsync(c=>c.StaffName.Contains(staffName));

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
            //var existingStaff = await _staffRepository.GetStaffByIdAsync(id);
            var existingStaff = await _staffRepository.GetByIdAsync(id);

            if (existingStaff == null)
                return false;

            existingStaff.StaffName = staffDto.StaffName;
            existingStaff.ClinicID = staffDto.ClinicID;
            existingStaff.ContactNumber = staffDto.ContactNumber;
            existingStaff.Email = staffDto.Email;
            existingStaff.DateOfJoining = staffDto.DateOfJoining;


            //var updateStaff = await _staffRepository.UpdateStaffAsync(existingStaff);
            var updateStaff = await _staffRepository.UpdateAsync(existingStaff);
            
            if (updateStaff == null)
                    return false;


            return true;



        }
    }
}
