using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Users;

public interface IAuthService
{
    ValueTask<string> GenerateToken(string username, string text);
}