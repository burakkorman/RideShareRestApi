using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RideShareRestApi.Entity.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen bir parola giriniz!")]
        public string Password { get; set; }
    }
}
