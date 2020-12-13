using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RideShareRestApi.Entity.Dto;
using RideShareRestApi.Service.Interfaces;

namespace RideShareRestApi.Controllers
{
    [Route("travelplan")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private readonly ITravelPlanService _travelPlanService;

        public TravelPlanController(ITravelPlanService travelPlanService)
        {
            _travelPlanService = travelPlanService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTravelPlanDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _travelPlanService.Create(model);

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

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTravelPlanDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _travelPlanService.Update(model);

                if (result)
                    return Ok();
                else
                    return NotFound();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("publish")]
        public async Task<IActionResult> Publish(Guid id)
        {
            if (ModelState.IsValid)
            {
                var result = await _travelPlanService.Publish(id);

                if (result)
                    return Ok();
                else
                    return NotFound();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("unpublish")]
        public async Task<IActionResult> UnPublish(Guid id)
        {
            if (ModelState.IsValid)
            {
                var result = await _travelPlanService.Unpublish(id);

                if (result)
                    return Ok();
                else
                    return NotFound();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _travelPlanService.Delete(id);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(Guid startCityId, Guid finishCityId)
        {
            var result = await _travelPlanService.Search(new SearchTravelPlanDto { StartCityId = startCityId, FinishCityId = finishCityId });

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
