using RideShareRestApi.Entity.Dto;
using System.Threading.Tasks;

namespace RideShareRestApi.Service.Interfaces
{
    public interface IUserService
    {
        CurrentUserDto CurrentUser { get; set; }
        bool ValidateToken(string token);
        Task<string> Login(LoginDto model);
        Task<bool> Register(UserDto model);
    }
}
