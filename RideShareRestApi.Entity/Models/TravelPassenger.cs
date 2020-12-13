using System;

namespace RideShareRestApi.Entity.Models
{
    public class TravelPassenger : BaseEntity
    {
        public Guid TravelPlanId { get; set; }
        public Guid UserId { get; set; }


        public TravelPlan TravelPlan { get; set; }
        public User User { get; set; }
    }
}
