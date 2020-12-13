using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideShareRestApi.Entity.Dto;
using RideShareRestApi.Service.Interfaces;

namespace RideShareRestApi.Controllers
{
    [Route("travelpassanger")]
    [ApiController]
    public class TravelPassengerController : ControllerBase
    {
        private readonly ITravelPassengerService _travelPassengerService;
        private readonly IUserService _userService;

        public TravelPassengerController(ITravelPassengerService travelPassengerService, IUserService userService)
        {
            _travelPassengerService = travelPassengerService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid travelPlanId)
        {
            if (ModelState.IsValid)
            {
                var result = await _travelPassengerService.Create(new TravelPassengerDto { TravelPlanId = travelPlanId, UserId = _userService.CurrentUser.Id });

                if (result)
                    return CreatedAtAction(nameof(Create), null);
                else
                    return BadRequest();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _travelPassengerService.Delete(id);

            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
