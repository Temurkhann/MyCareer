using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<Region> regionRepository;
        private readonly IGenericRepository<Country> countryRepository;
        private readonly IGenericRepository<Address> addressRepository;
        private readonly IMapper mapper;

        public AddressService(IGenericRepository<Region> regionRepository, IGenericRepository<Country> countryRepository, IGenericRepository<Address> addressRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.countryRepository = countryRepository;
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Address> CreateAsync(AddressForCreationDTO addressForCreationDTO)
        {
            var existCountry = await countryRepository.GetAsync(
                c => c.Id == addressForCreationDTO.CountryId);

            if (existCountry == null)
                throw new MyCareerException(404, "Hobby not found");

            var existRegion = await regionRepository.GetAsync(
                r => r.Id == addressForCreationDTO.RegionId);

            if (existRegion == null)
                throw new MyCareerException(404, "User not found");

            var createdUserHobby = await addressRepository.CreateAsync(mapper.Map<Address>(addressForCreationDTO));
            await addressRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await addressRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "UserHobby not found");

            await addressRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Address>> GetAll(PaginationParams @params, Expression<Func<Address, bool>> expression = null)
        {
            var addresses = addressRepository.GetAll(expression: expression, isTracking: false);

            return await addresses.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Address> GetAsync(Expression<Func<Address, bool>> expression)
        {
            var address = await addressRepository.GetAsync(expression, false, new string[] { "User", "Hobby" });

            if (address is null)
                throw new MyCareerException(404, "UserHobby not found");

            return address;
        }

        public async ValueTask<Address> UpdateAsync(int id, AddressForCreationDTO addressForCreationDTO)
        {
            var existAddress = await addressRepository.GetAsync(f => f.Id == id);

            if (existAddress is null)
                throw new MyCareerException(404, "Address not found");

            var existCountry = await countryRepository.GetAsync(
                c => c.Id == addressForCreationDTO.CountryId);

            if (existCountry == null)
                throw new MyCareerException(404, "Contry not found");

            var existRegion = await regionRepository.GetAsync(
                r => r.Id == addressForCreationDTO.RegionId);

            if (existRegion == null)
                throw new MyCareerException(404, "Region not found");

            existAddress.UpdatedAt = DateTime.UtcNow;
            existAddress = addressRepository.Update(mapper.Map(addressForCreationDTO, existAddress));
            await addressRepository.SaveChangesAsync();

            return existAddress;
        }
    }
}
