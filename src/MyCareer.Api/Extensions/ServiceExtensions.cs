using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyCareer.Data.IRepositories;
using MyCareer.Data.Repositories;
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
using MyCareer.Service.Interfaces.Addresses;
using MyCareer.Service.Interfaces.Attachments;
using MyCareer.Service.Interfaces.Chats;
using MyCareer.Service.Interfaces.Companies;
using MyCareer.Service.Interfaces.Contacts;
using MyCareer.Service.Interfaces.Contracts;
using MyCareer.Service.Interfaces.Educations;
using MyCareer.Service.Interfaces.Experiences;
using MyCareer.Service.Interfaces.Freelancers;
using MyCareer.Service.Interfaces.Hobbies;
using MyCareer.Service.Interfaces.IUsers;
using MyCareer.Service.Interfaces.Jobs;
using MyCareer.Service.Interfaces.Languages;
using MyCareer.Service.Interfaces.Likes;
using MyCareer.Service.Interfaces.Messages;
using MyCareer.Service.Interfaces.Resumes;
using MyCareer.Service.Interfaces.Skills;
using MyCareer.Service.Interfaces.Talents;
using MyCareer.Service.Interfaces.Users;
using MyCareer.Service.Services.Addresses;
using MyCareer.Service.Services.Attachments;
using MyCareer.Service.Services.Chats;
using MyCareer.Service.Services.Companies;
using MyCareer.Service.Services.Contacts;
using MyCareer.Service.Services.Contracts;
using MyCareer.Service.Services.Educations;
using MyCareer.Service.Services.Experiences;
using MyCareer.Service.Services.Freelancers;
using MyCareer.Service.Services.Hobbies;
using MyCareer.Service.Services.Jobs;
using MyCareer.Service.Services.Languages;
using MyCareer.Service.Services.Likes;
using MyCareer.Service.Services.Resumes;
using MyCareer.Service.Services.Skills;
using MyCareer.Service.Services.Talents;
using MyCareer.Service.Services.Users;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyCareer.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<UserHobby>, GenericRepository<UserHobby>>();
            services.AddScoped<IGenericRepository<UserSkill>, GenericRepository<UserSkill>>();
            services.AddScoped<IGenericRepository<UserLanguage>, GenericRepository<UserLanguage>>();
            services.AddScoped<IGenericRepository<Talent>, GenericRepository<Talent>>();
            services.AddScoped<IGenericRepository<Skill>, GenericRepository<Skill>>();
            services.AddScoped<IGenericRepository<Resume>, GenericRepository<Resume>>();
            services.AddScoped<IGenericRepository<Like>, GenericRepository<Like>>();
            services.AddScoped<IGenericRepository<Language>, GenericRepository<Language>>();
            services.AddScoped<IGenericRepository<Freelancer>, GenericRepository<Freelancer>>();
            services.AddScoped<IGenericRepository<Company>, GenericRepository<Company>>();
            services.AddScoped<IGenericRepository<Hobby>, GenericRepository<Hobby>>();
            services.AddScoped<IGenericRepository<Job>, GenericRepository<Job>>();
            services.AddScoped<IGenericRepository<JobSkill>, GenericRepository<JobSkill>>();
            services.AddScoped<IGenericRepository<Experience>, GenericRepository<Experience>>();
            services.AddScoped<IGenericRepository<Region>, GenericRepository<Region>>();
            services.AddScoped<IGenericRepository<Country>, GenericRepository<Country>>();
            services.AddScoped<IGenericRepository<Address>, GenericRepository<Address>>();
            services.AddScoped<IGenericRepository<Attachment>, GenericRepository<Attachment>>();
            services.AddScoped<IGenericRepository<Education>, GenericRepository<Education>>();
            services.AddScoped<IGenericRepository<Contract>, GenericRepository<Contract>>();
            services.AddScoped<IGenericRepository<ContractSkill>, GenericRepository<ContractSkill>>();
            services.AddScoped<IGenericRepository<Contact>, GenericRepository<Contact>>();
            services.AddScoped<IGenericRepository<PerformerDetails>, GenericRepository<PerformerDetails>>();
            services.AddScoped<IGenericRepository<Chat>, GenericRepository<Chat>>();
            services.AddScoped<IGenericRepository<Message>, GenericRepository<Message>>();

            // services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IUserHobbyService, UserHobbyService>();
            services.AddScoped<IUserSkillService, UserSkillService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITalentService, TalentService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IHobbyService, HobbyService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IJobSkillService, JobSkillService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IContractSkillService, ContractSkillService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IPerformerDetailService, PerformerDetailService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            string key = jwtSettings.GetSection("Secret").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))

                };
            });
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(p =>
            {
                p.ResolveConflictingActions(ad => ad.First());
                p.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                });

                p.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }
    }
}
