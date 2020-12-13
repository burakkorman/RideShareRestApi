using System;

namespace RideShareRestApi.Entity.Models
{
    public class TravelPlan : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid StartCityId { get; set; }
        public Guid FinishCityId { get; set; }
        public DateTime TravelTime { get; set; }
        public int SeatsCount { get; set; }
        public string Description { get; set; }
        public bool IsPublish { get; set; }

        public User User { get; set; }
        public City StartCity { get; set; }
        public City FinishCity { get; set; }
    }
}
