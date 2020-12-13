using System;

namespace RideShareRestApi.Entity.Dto
{
    public class SearchTravelPlanDto
    {
        public Guid StartCityId { get; set; }
        public Guid FinishCityId { get; set; }
    }
}
