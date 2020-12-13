using System.ComponentModel.DataAnnotations;

namespace RideShareRestApi.Entity.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen bir parola giriniz!")]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
