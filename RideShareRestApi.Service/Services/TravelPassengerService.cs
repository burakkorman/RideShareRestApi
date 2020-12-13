using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RideShareRestApi.Entity.Dto;
using RideShareRestApi.Entity.Models;
using RideShareRestApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShareRestApi.Service.Services
{
    public class TravelPassengerService : ITravelPassengerService
    {
        private readonly RideShareContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITravelPlanService _travelPlanService;

        public TravelPassengerService(RideShareContext context, IMapper mapper, IUserService userService, ITravelPlanService travelPlanService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _travelPlanService = travelPlanService;
        }

        public async Task<bool> Create(TravelPassengerDto model)
        {
            if (await _context.TravelPassengers.AnyAsync(x => x.TravelPlanId == model.TravelPlanId && x.UserId == model.UserId && !x.IsDeleted))
                return false;

            var travelPlan = _context.TravelPlans.SingleOrDefault(x => x.Id == model.TravelPlanId);
            var passengers = await _context.TravelPassengers.Where(x => x.TravelPlanId == x.TravelPlanId && !x.IsDeleted).ToListAsync();

            var data = _mapper.Map<TravelPassenger>(model);

            if (travelPlan.SeatsCount > passengers.Count)
                await _context.TravelPassengers.AddAsync(data);
            else
                return false;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var data = await _context.TravelPassengers.SingleOrDefaultAsync(x => x.Id == id);
            data.IsDeleted = true;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
