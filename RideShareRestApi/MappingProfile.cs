using AutoMapper;
using RideShareRestApi.Entity.Dto;
using RideShareRestApi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShareRestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CurrentUserDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();


            CreateMap<CreateTravelPlanDto, TravelPlan>();
            CreateMap<TravelPlanDto, TravelPlan>();
            CreateMap<TravelPlan, TravelPlanDto>();


            CreateMap<TravelPassengerDto, TravelPassenger>();
            CreateMap<TravelPassenger, TravelPassengerDto>();
        }
    }
}
