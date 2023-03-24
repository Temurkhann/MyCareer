using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Likes;
using MyCareer.Domain.Entities.Talents;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.DTOs.Likes;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Likes
{
    public class LikeService : ILikeService
    {
        private readonly IGenericRepository<Talent> talentRepository;
        private readonly IGenericRepository<User> userRepository;
        private readonly IGenericRepository<Like> likeRepository;
        private readonly IMapper mapper;

        public LikeService(IGenericRepository<Talent> talentRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<Like> likeRepository,
            IMapper mapper)
        {
            this.talentRepository = talentRepository;
            this.userRepository = userRepository;
            this.likeRepository = likeRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Like> CreateAsync(LikeForCreationDTO likeForCreationDTO)
        {
            var existTalent = await talentRepository.GetAsync(
                c => c.Id == likeForCreationDTO.TalentId);

            if (existTalent == null)
                throw new MyCareerException(404, "Talent not found");

            var existUser = await userRepository.GetAsync(
                r => r.Id == likeForCreationDTO.UserId);

            if (existUser == null)
                throw new MyCareerException(404, "User not found");

            var createdFreelanser = await likeRepository.CreateAsync(mapper.Map<Like>(likeForCreationDTO));
            await likeRepository.SaveChangesAsync();

            return createdFreelanser;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await likeRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "UserSkill not found");

            await likeRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Like>> GetAll(PaginationParams @params, Expression<Func<Like, bool>> expression = null)
        {
            var likes = likeRepository.GetAll(expression: expression, isTracking: false);

            return await likes.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Like> GetAsync(Expression<Func<Like, bool>> expression)
        {
            var userLanguage = await likeRepository.GetAsync(expression, false, new string[] { "User", "Skill" });

            if (userLanguage is null)
                throw new MyCareerException(404, "UserSkill not found");

            return userLanguage;
        }
    }
}
