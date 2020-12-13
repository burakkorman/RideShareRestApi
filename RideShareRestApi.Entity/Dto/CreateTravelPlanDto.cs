using System;

namespace RideShareRestApi.Entity.Dto
{
    public class CreateTravelPlanDto
    {
        public Guid StartCityId { get; set; }
        public Guid FinishCityId { get; set; }
        public DateTime TravelTime { get; set; }
        public int SeatsCount { get; set; }
        public string Description { get; set; }
    }

    public class UpdateTravelPlanDto : CreateTravelPlanDto
    {
        public Guid Id { get; set; }
    }
}
