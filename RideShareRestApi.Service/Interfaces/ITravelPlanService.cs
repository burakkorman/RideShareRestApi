using RideShareRestApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RideShareRestApi.Service.Interfaces
{
    public interface ITravelPlanService
    {
        Task<bool> Create(CreateTravelPlanDto model);
        Task<bool> Update(UpdateTravelPlanDto model);
        Task<TravelPlanDto> Get(Guid id);
        Task<IEnumerable<TravelPlanDto>> GetAll();
        Task<bool> Publish(Guid id);
        Task<bool> Unpublish(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<TravelPlanDto>> Search(SearchTravelPlanDto model);
    }
}
