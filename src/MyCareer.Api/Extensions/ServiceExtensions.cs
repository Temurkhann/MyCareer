using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyCareer.Data.IRepositories;
using MyCareer.Data.Repositories;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Languages;
using MyCareer.Domain.Entities.Likes;
using MyCareer.Domain.Entities.Resumes;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Domain.Entities.Talents;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.Interfaces.Companies;
using MyCareer.Service.Interfaces.Freelancers;
using MyCareer.Service.Interfaces.IUsers;
using MyCareer.Service.Interfaces.Languages;
using MyCareer.Service.Interfaces.Likes;
using MyCareer.Service.Interfaces.Resumes;
using MyCareer.Service.Interfaces.Skills;
using MyCareer.Service.Interfaces.Talents;
using MyCareer.Service.Interfaces.Users;
using MyCareer.Service.Services.Companies;
using MyCareer.Service.Services.Freelancers;
using MyCareer.Service.Services.Languages;
using MyCareer.Service.Services.Likes;
using MyCareer.Service.Services.Resumes;
using MyCareer.Service.Services.Skills;
using MyCareer.Service.Services.Talents;
using MyCareer.Service.Services.Users;
using System.Text;


namespace ZaminEducation.Api
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
