using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Extensions;
using MyCareer.Service.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Users;

public class AuthService : IAuthService
{
    private readonly IGenericRepository<User> userRepository;
    private readonly IConfiguration configuration;

    public AuthService(IGenericRepository<User> userRepository, IConfiguration configuration)
    {
        this.userRepository = userRepository;
        this.configuration = configuration;
    }
    public async ValueTask<string> GenerateToken(string email, string text)
    {
        User user = await userRepository.GetAsync(u =>
            u.Email == email && u.Password.Equals(text.Encrypt()));

        if (user is null)
            throw new MyCareerException(400, "Login or Password is incorrect");

        var authSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            expires: DateTime.Now.AddHours(int.Parse(configuration["JWT:Expire"])),
            claims: new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            },
            signingCredentials: new SigningCredentials(
                key: authSigningKey,
                algorithm: SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}