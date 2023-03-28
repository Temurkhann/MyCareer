using AutoMapper;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Chats;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Chats
{
    public class MessageService : IMessageService
    {
        private readonly IGenericRepository<Message> messageRepository;
        private readonly IGenericRepository<Company> companyRepository;
        private readonly IGenericRepository<Freelancer> freelancerRepository;
        private readonly IGenericRepository<User> userRepository;
        private readonly IMapper mapper;

        public async ValueTask<Message> CreateAsync(MessageForCreationDTO messageForCreationDTO)
        {
            var existChat = await companyRepository.GetAsync(c => c.Id == messageForCreationDTO.ChatId);

            if (existChat == null)
                throw new MyCareerException(404, "Chat not found");

            var existUser = await userRepository.GetAsync(u => u.Id == messageForCreationDTO.UserId);

            var existCompany = await companyRepository.GetAsync(c => c.Id == messageForCreationDTO.ChatId);

            var message = await messageRepository.CreateAsync(mapper.Map<Message>(messageForCreationDTO));
            await messageRepository.SaveChangesAsync();

            return message;
        }
    }
}
