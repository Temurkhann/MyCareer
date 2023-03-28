using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Chats;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IGenericRepository<Chat> chatRepository;
        private readonly IGenericRepository<Freelancer> freelancerRepository;
        private readonly IGenericRepository<Company> companyRepository;
        private readonly IMapper mapper;

        public async ValueTask<Chat> CreateAsync(ChatForCreationDTO chatForCreationDTO)
        {
            var existCompany = await companyRepository.GetAsync(c => c.Id == chatForCreationDTO.CompanyId);

            if (existCompany == null)
                throw new MyCareerException(404, "Company not found");

            var existFreelancer = await freelancerRepository.GetAsync(f => f.Id == chatForCreationDTO.FreelancerId);

            if (existFreelancer == null)
                throw new MyCareerException(404, "Freelancer not found");

            var createdChat = await chatRepository.CreateAsync(mapper.Map<Chat>(chatForCreationDTO));
            await chatRepository.SaveChangesAsync();

            return createdChat;
        }

        public async ValueTask<IEnumerable<Chat>> GetAll(PaginationParams @params, Expression<Func<Chat, bool>> expression = null)
        {   
            var chats = chatRepository.GetAll(expression: expression, isTracking: false);
            return await chats.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Chat> GetAsync(Expression<Func<Chat, bool>> expression)
        {
            var chat = await chatRepository.GetAsync(expression, false, new string[] { "Messages", "User" });
            
            if (chat is null)
                throw new MyCareerException(404, "Chat not found");
            
            return chat;
        }
    }
}
