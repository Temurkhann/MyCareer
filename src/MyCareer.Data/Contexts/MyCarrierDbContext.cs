using Microsoft.EntityFrameworkCore;
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
using MyCarrier.Domain.Entities.Jobs;
using MyCarrier.Domain.Entities.Skills;

namespace MyCareer.Data.Contexts;
public class MyCarrierDbContext : DbContext
{
    public MyCarrierDbContext(DbContextOptions<MyCarrierDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<UserLanguage> UserLanguages { get; set; }
    public DbSet<Hobby> Hobbies { get; set;}
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserContact> UserContacts { get; set; }
    public DbSet<UserHobby> UserHobbies { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<JobSkill> JobSkills { get; set; }
    public DbSet<CompanyInformation> CompanyInformation { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<ContractSkill> ContractSkills { get; set; }
    public DbSet<Talent> Talents { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Chat> Chats { get; set; }  
    public DbSet<PerformerDetails> PerformerDetails { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    
        modelBuilder.Entity<Freelancer>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
