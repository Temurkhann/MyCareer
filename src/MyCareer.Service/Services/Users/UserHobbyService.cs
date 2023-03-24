using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Users
{
    public class UserHobbyService : IUserHobbyService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Hobby> hobbyRepository;
        private readonly IGenericRepository<UserHobby> userHobbyRepository;
        private readonly IMapper mapper;

        public UserHobbyService(IGenericRepository<User> userRepository, IGenericRepository<Hobby> hobbyRepository, IGenericRepository<UserHobby> userHobbyRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.hobbyRepository = hobbyRepository;
            this.userHobbyRepository = userHobbyRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserHobby> CreateAsync(UserHobbyForCreationDTO userHobbyForCreationDTO)
        {
            var existHobby = await hobbyRepository.GetAsync(
                c => c.Id == userHobbyForCreationDTO.HobbyId);

            if (existHobby == null)
                throw new MyCareerException(404, "Hobby not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == userHobbyForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            var createdUserHobby = await userHobbyRepository.CreateAsync(mapper.Map<UserHobby>(userHobbyForCreationDTO));
            await userHobbyRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await userHobbyRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "UserHobby not found");

            await userHobbyRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<UserHobby>> GetAll(PaginationParams @params, Expression<Func<UserHobby, bool>> expression = null)
        {
            var userHobbies = userHobbyRepository.GetAll(expression: expression, isTracking: false);

            return await userHobbies.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<UserHobby> GetAsync(Expression<Func<UserHobby, bool>> expression)
        {
            var userHobby = await userHobbyRepository.GetAsync(expression, false, new string[] { "User", "Hobby"});

            if (userHobby is null)
                throw new MyCareerException(404, "UserHobby not found");

            return userHobby;
        }

        public async ValueTask<UserHobby> Update(int id, UserHobbyForCreationDTO userHobbyForCreation)
        {
            var existUserHobby = await userHobbyRepository.GetAsync(f => f.Id == id);

            if (existUserHobby is null)
                throw new MyCareerException(404, "UserHobby not found");

            var existHobby = await hobbyRepository.GetAsync(
                c => c.Id == userHobbyForCreation.HobbyId);

            if (existHobby == null)
                throw new MyCareerException(404, "Hobby not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == userHobbyForCreation.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            existUserHobby.UpdatedAt = DateTime.UtcNow;
            existUserHobby = userHobbyRepository.Update(mapper.Map(userHobbyForCreation, existUserHobby));
            await userHobbyRepository.SaveChangesAsync();

            return existUserHobby;
        }
    }
}
