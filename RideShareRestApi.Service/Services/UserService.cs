using AutoMapper;
using Jose;
using Microsoft.EntityFrameworkCore;
using RideShareRestApi.Entity.Dto;
using RideShareRestApi.Entity.Models;
using RideShareRestApi.Service.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace RideShareRestApi.Service.Services
{
    public class UserService : IUserService
    {
        public CurrentUserDto CurrentUser { get; set; }
        private const string _jwtKey = "msCcNCTw8RCZVSF3Sn";

        private readonly RideShareContext _context;
        private readonly IMapper _mapper;

        public UserService(RideShareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Login(LoginDto model)
        {
            var user = await _context
                .Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Username == model.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                return null;

            return JWT.Encode(_mapper.Map<CurrentUserDto>(user),
                Encoding.UTF8.GetBytes(_jwtKey),
                JwsAlgorithm.HS256);
        }

        public async Task<bool> Register(UserDto model)
        {
            if (await _context.Users.AnyAsync(x => x.Username == model.Username))
                return false;

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            await _context.Users.AddAsync(_mapper.Map<User>(model));
            return await _context.SaveChangesAsync() > 0;
        }

        public bool ValidateToken(string token)
        {
            try
            {
                CurrentUser = JWT.Decode<CurrentUserDto>(token, Encoding.UTF8.GetBytes(_jwtKey));
            }
            catch
            {
                return false;
            }

            return CurrentUser != null;
        }
    }
}
