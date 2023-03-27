using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IGenericRepository<Contact> contactRepository;
        private readonly IMapper mapper;

        public ContactService(IGenericRepository<Contact> contactRepository, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Contact> CreateAsync(ContactForCreationDTO contactForCreationDTO)
        {
            var createdUserHobby = await contactRepository.CreateAsync(mapper.Map<Contact>(contactRepository));
            await contactRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await contactRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Contact not found");

            await contactRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Contact>> GetAll(PaginationParams @params, Expression<Func<Contact, bool>> expression = null)
        {
            var skills = contactRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User" });

            return await skills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Contact> GetAsync(Expression<Func<Contact, bool>> expression)
        {
            var skill = await contactRepository.GetAsync(expression, false);

            if (skill is null)
                throw new MyCareerException(404, "Contact not found");

            return skill;
        }

        public async ValueTask<Contact> Update(int id, ContactForCreationDTO contactForCreationDTO)
        {
            var existSkill = await contactRepository.GetAsync(f => f.Id == id);

            if (existSkill is null)
                throw new MyCareerException(404, "Skill not found");

            existSkill.UpdatedAt = DateTime.UtcNow;
            existSkill = contactRepository.Update(mapper.Map(contactForCreationDTO, existSkill));
            await contactRepository.SaveChangesAsync();

            return existSkill;
        }
    }
}
