using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RideShareRestApi.Entity.Dto;
using RideShareRestApi.Entity.Models;
using RideShareRestApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShareRestApi.Service.Services
{
    public class TravelPlanService : ITravelPlanService
    {
        private readonly RideShareContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public TravelPlanService(RideShareContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<bool> Create(CreateTravelPlanDto model)
        {
            var travelPlan = _mapper.Map<TravelPlan>(model);
            travelPlan.UserId = _userService.CurrentUser.Id;
            travelPlan.IsPublish = false;

            await _context.TravelPlans.AddAsync(travelPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(UpdateTravelPlanDto model)
        {
            var travelPlan = await _context.TravelPlans.SingleOrDefaultAsync(x => x.Id == model.Id && !x.IsDeleted);
            if (travelPlan == null)
                return false;

            _mapper.Map(model, travelPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var travelPlan = await _context.TravelPlans.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (travelPlan == null)
                return false;
            travelPlan.IsDeleted = true;

            _context.TravelPlans.Update(travelPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TravelPlanDto> Get(Guid id)
        {
            return _mapper.Map<TravelPlanDto>(
                await _context
                    .TravelPlans
                    .SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted)
                );
        }

        public async Task<IEnumerable<TravelPlanDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<TravelPlanDto>>(
                await _context
                    .TravelPlans
                    .Where(x => !x.IsDeleted)
                    .ToListAsync()
                );
        }

        public async Task<bool> Publish(Guid id)
        {
            var travelPlan = await _context.TravelPlans.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (travelPlan == null)
                return false;
            travelPlan.IsPublish = true;

            _context.TravelPlans.Update(travelPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Unpublish(Guid id)
        {
            var travelPlan = await _context.TravelPlans.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (travelPlan == null)
                return false;
            travelPlan.IsPublish = false;

            _context.TravelPlans.Update(travelPlan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TravelPlanDto>> Search(SearchTravelPlanDto model)
        {
            //ADA, DİKEYDE 10 VE YATAYDA 20 ŞEHİR UZUNLUĞUNA SAHİPTİR. TOPLAM 200 ŞEHİR VARDIR.
            //1. ŞEHİRDEN 200. ŞEHİRE GİDEN BİR KULLANICI, TÜM ŞEHİRLERDEN GEÇMEKTEDİR.
            //50. ŞEHİRDEN 100. ŞEHİRE GİDEN BİR KULLANICI, 50. ŞEHİR VE 100. ŞEHİR ARASINDAKİ TÜM ŞEHİRLERDEN GEÇMEKTEDİR.

            var startCity = await _context.Cities.SingleOrDefaultAsync(x => x.Id == model.StartCityId);
            var finishCity = await _context.Cities.SingleOrDefaultAsync(x => x.Id == model.FinishCityId);

            var travelPlans = await _context.TravelPlans
                                        .Include(u => u.User)
                                        .Include(c => c.StartCity)
                                        .Include(c => c.FinishCity)
                                        .Where(x => x.IsPublish && !x.IsDeleted
                                                    && startCity.CityNumber >= x.StartCity.CityNumber
                                                    && finishCity.CityNumber <= x.FinishCity.CityNumber)
                                        .ToListAsync();

            return travelPlans.Select(x => new TravelPlanDto
            {
                UserId = x.UserId,
                StartCityId = x.StartCityId,
                FinishCityId = x.FinishCityId,
                Description = x.Description,
                StartCityName = x.StartCity.CityName,
                FinishCityName = x.FinishCity.CityName,
                SeatsCount = x.SeatsCount,
                TravelTime = x.TravelTime,
                UserNameSurname = x.User.Name + " " + x.User.Surname
            });
        }
    }
}
