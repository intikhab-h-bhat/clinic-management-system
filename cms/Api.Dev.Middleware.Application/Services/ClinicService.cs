using Api.Dev.Middleware.Application.Dtos.ClinicDto;
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
    public class ClinicService : IClinicService
    {
        // private readonly IClinicRepository _clinicRepository;
        private readonly IRepository<Clinic> _clinicRepository;

        public ClinicService(IRepository<Clinic> clinicRepository
            //IClinicRepository clinicRepository
            )
        {
            _clinicRepository = clinicRepository;
        }

        public async Task<ClinicDto> AddClinicAsync(ClinicDto clinicDto)
        {
            

            Clinic addClinic = new Clinic();
            addClinic.ClinicName = clinicDto.ClinicName;
            addClinic.Address = clinicDto.Address;
            addClinic.Email = clinicDto.Email;
            addClinic.ContactNumber = clinicDto.ContactNumber;
            addClinic.Website = clinicDto.Website;

            //var clinicStatus = await _clinicRepository.AddClinicAsync(addClinic);
            var clinicStatus = await _clinicRepository.AddAsync(addClinic);

            var addClinicDto = new ClinicDto
            {
                ClinicID=clinicStatus.ClinicID,
                ClinicName = clinicStatus.ClinicName,
                Address = clinicStatus.Address,
                Email = clinicStatus.Email,
                ContactNumber = clinicStatus.ContactNumber,
                Website = clinicStatus.Website   
            };

            return addClinicDto;
            
        }

        public async Task<bool> DeleteClinicAsync(int id)
        {

            // return await  _clinicRepository.DeleteClinicAsync(id);
            var existingClinic = await _clinicRepository.GetByIdAsync(id);
            if (existingClinic==null)
                return false;
              
               await _clinicRepository.DeleteAsync(existingClinic);
            return true;
        }

        public async Task<IEnumerable<ClinicDto>> GetAllClinicsAsync()
        {

            //var allClinics = await _clinicRepository.GeatAllClinicAsync();
            var allClinics = await _clinicRepository.GeatAllAsync();
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

        public async Task<ClinicDto> GetClinicByIdAsync(int id)
        {
            // var getClinic = await _clinicRepository.GetClinicByIdAsync(id);
            var getClinic = await _clinicRepository.GetByIdAsync(id);

            if (getClinic == null)
                return null;

            var getClinicDto = new ClinicDto
            {
                ClinicID=getClinic.ClinicID,
                ClinicName=getClinic.ClinicName,
                Address=getClinic.Address,
                ContactNumber=getClinic.ContactNumber,
                Email=getClinic.ContactNumber
            };

            return getClinicDto;
           
        }

        public async Task<ClinicDto> GetClinicByNameAsync(string clinicName)
        {
            //var getClinicByName = await _clinicRepository.GetClinicByNameAsync(clinicName);
            var getClinicByName = await _clinicRepository.GetByNameAsync(c => c.ClinicName.Contains(clinicName));

            if (getClinicByName == null)
                return null;

            var getClinicByNameDto = new ClinicDto
            {
                ClinicID=getClinicByName.ClinicID,
                ClinicName=getClinicByName.ClinicName,
                Address=getClinicByName.Address,
                ContactNumber=getClinicByName.ContactNumber,
                Email = getClinicByName.Email,
                Website = getClinicByName.Website

            };


            return getClinicByNameDto;
        }

        public async Task<ClinicDto> UpdateClinicAsync(int id, ClinicDto clinicDto)
        {
            //var existingClinic = await _clinicRepository.GetClinicByIdAsync(id);
            var existingClinic = await _clinicRepository.GetByIdAsync(id);

            if (existingClinic == null)
                return null;

            existingClinic.ClinicName = clinicDto.ClinicName;
            existingClinic.ContactNumber = clinicDto.ContactNumber;
            existingClinic.Email = clinicDto.Email;
            existingClinic.Address = clinicDto.Address;
            existingClinic.Website = clinicDto.Website;


            //var UpdateClinic = await _clinicRepository.UpdateClinicAsync(id, existingClinic);
            var UpdateClinic = await _clinicRepository.UpdateAsync(existingClinic);

            return clinicDto;
            
        }




    }
}
