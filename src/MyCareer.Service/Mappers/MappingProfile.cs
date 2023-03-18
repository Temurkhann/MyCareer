using AutoMapper;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Domain.Entities.Experiences;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Domain.Entities.Likes;
using MyCareer.Domain.Entities.Resumes;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Domain.Entities.Talents;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.DTOs.Attachments;
using MyCareer.Service.DTOs.Chats;
using MyCareer.Service.DTOs.Companies;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.DTOs.Countries;
using MyCareer.Service.DTOs.Educations;
using MyCareer.Service.DTOs.Experiences;
using MyCareer.Service.DTOs.Freelancers;
using MyCareer.Service.DTOs.Hobbies;
using MyCareer.Service.DTOs.Jobs;
using MyCareer.Service.DTOs.Languages;
using MyCareer.Service.DTOs.Likes;
using MyCareer.Service.DTOs.Messages;
using MyCareer.Service.DTOs.Regions;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.DTOs.Talents;
using MyCareer.Service.DTOs.Users;

namespace MyCareer.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // user
            CreateMap<User, UserForCreationDTO>().ReverseMap();
            CreateMap<User, UserForViewDTO>().ReverseMap();
            CreateMap<UserContact, UserContactForCreationDTO>().ReverseMap();
            CreateMap<UserHobby, UserHobbyForCreationDTO>().ReverseMap();
            CreateMap<UserLanguage, UserLanguageForCreationDTO>().ReverseMap();
            CreateMap<Freelancer, FreelancerForCreationDTO>().ReverseMap();


            // talent
            CreateMap<Talent, TalentForCreationDTO>().ReverseMap();

            // skill
            CreateMap<Skill, SkillForCreationDTO>().ReverseMap();

            // resume
            CreateMap<Resume, ResumeForCreationDTO>().ReverseMap();

            // like
            CreateMap<Like, LikeForCreationDTO>().ReverseMap();

            // language
            CreateMap<Language, LanguageForCreationDTO>().ReverseMap();

            // job
            CreateMap<JobForCreationDTO, JobForCreationDTO>().ReverseMap();
            CreateMap<JobSkill, JobSkillForCreationDTO>().ReverseMap();

            // hobby
            CreateMap<Hobby, HobbyForCreationDTO>().ReverseMap();

            // experience
            CreateMap<Experience, ExperienceForCreationDTO>().ReverseMap();

            // education
            CreateMap<Education, EducationForCreationDTO>().ReverseMap();

            // contract
            CreateMap<Contract, ContractForCreationDTO>().ReverseMap();
            CreateMap<ContractSkill, ContractSkillForCreationDTO>().ReverseMap();
            CreateMap<PerformerDetails, PerformerDetailForCreationDTO>().ReverseMap();

            // contact
            CreateMap<Contact, ContactForCreationDTO>().ReverseMap();

            // company
            CreateMap<Company, CompanyForCreationDTO>().ReverseMap();
            CreateMap<CompanyInformation, CompanyInformationForCreationDTO>().ReverseMap();

            //chat
            CreateMap<Chat, ChatForCreationDTO>().ReverseMap();
            CreateMap<Message, MessageForCreationDTO>().ReverseMap();

            // attachment
            CreateMap<Attachment, AttachmentForCreationDTO>().ReverseMap();

            // address
            CreateMap<Address, AddressForCreationDTO>().ReverseMap();
            CreateMap<Country, CountryForCreationDTO>().ReverseMap();
            CreateMap<Region, RegionForCreationDTO>().ReverseMap();
        }
    }
}
