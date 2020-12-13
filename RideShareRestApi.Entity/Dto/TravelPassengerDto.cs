using System;
using System.Collections.Generic;
using System.Text;

namespace RideShareRestApi.Entity.Dto
{
    public class TravelPassengerDto
    {
        public Guid TravelPlanId { get; set; }
        public Guid UserId { get; set; }
    }
}
