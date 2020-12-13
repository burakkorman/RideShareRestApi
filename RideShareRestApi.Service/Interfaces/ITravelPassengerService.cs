using RideShareRestApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RideShareRestApi.Service.Interfaces
{
    public interface ITravelPassengerService
    {
        Task<bool> Create(TravelPassengerDto model);
        Task<bool> Delete(Guid id);
    }
}
