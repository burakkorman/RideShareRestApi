using System;

namespace RideShareRestApi.Entity.Dto
{
    public class CurrentUserDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
