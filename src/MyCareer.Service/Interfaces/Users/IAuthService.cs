using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Users;

public interface IAuthService
{
    ValueTask<string> GenerateToken(string email, string text);
}