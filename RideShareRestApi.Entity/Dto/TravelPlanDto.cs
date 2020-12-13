using System;

namespace RideShareRestApi.Entity.Dto
{
    public class TravelPlanDto
    {
        public Guid UserId { get; set; }
        public Guid StartCityId { get; set; }
        public Guid FinishCityId { get; set; }
        public string UserNameSurname { get; set; }
        public string StartCityName { get; set; }
        public string FinishCityName { get; set; }
        public DateTime TravelTime { get; set; }
        public int SeatsCount { get; set; }
        public string Description { get; set; }
    }
}
