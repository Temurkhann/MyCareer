using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Extensions;
using MyCareer.Service.Helpers;
using MyCareer.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IMapper mapper;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<bool> ChangePasswordAsync(UserForChangePasswordDTO userForChangePasswordDTO)
        {
            var user = await userRepository.GetAsync(u => u.Id == HttpContextHelper.UserId);

            if (user == null)
                throw new MyCareerException(404, "User not found");

            if (user.Password != userForChangePasswordDTO.OldPassword.Encrypt())
                throw new MyCareerException(400, "Password is incorrect");


            user.Password = userForChangePasswordDTO.NewPassword.Encrypt();

            userRepository.Update(user);
            await userRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
        {
            var existEmail = await userRepository.GetAsync(u => u.Email == userForCreationDTO.Email);

            if (existEmail != null)
                throw new MyCareerException(400, "This email is already taken");

            var createdUser = await userRepository.CreateAsync(mapper.Map<User>(userForCreationDTO));

            createdUser.Password = createdUser.Password.Encrypt();

            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(createdUser);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await userRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "User not found");

            await userRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            var users = userRepository.GetAll(expression: expression, isTracking: false);

            return mapper.Map<List<UserForViewDTO>>(await users.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await userRepository.GetAsync(expression);

            if (user is null)
                throw new MyCareerException(404, "User not found");

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<UserForViewDTO> UpdateAsync(int id, UserForUpdateDTO userForUpdateDTO)
        {
            var existUser = await userRepository.GetAsync(
                u => u.Id == id);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            var alreadyExistUser = await userRepository.GetAsync(
                u => u.Email == userForUpdateDTO.Email && u.Id != HttpContextHelper.UserId);

            if (alreadyExistUser != null)
                throw new MyCareerException(400, "User with such email already exists");


            existUser.UpdatedAt = DateTime.UtcNow;
            existUser = userRepository.Update(mapper.Map(userForUpdateDTO, existUser));
            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(existUser);
        }
    }
}
