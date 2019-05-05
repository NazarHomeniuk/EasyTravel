using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTravel.API.Models;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Contracts.Interfaces.Core;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Services.BlaBlaCar;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlaBlaCarController : ControllerBase
    {
        private readonly ITripFinder tripFinder;

        public BlaBlaCarController(BlaBlaCarFinder blaBlaCarFinder)
        {
            tripFinder = blaBlaCarFinder;
        }

        [HttpPost]
        [Route("find")]
        public async Task<IEnumerable<ITrip>> Find(Request request)
        {
            return await tripFinder.FindTripsAsync(request.From, request.To, request.Date);
        }

        [HttpPost]
        [Route("findAll")]
        public async Task<IEnumerable<ITrip>> FindAll(Request request)
        {
            return await tripFinder.FindAllTripsAsync(request.From, request.To, request.Date);
        }
    }
}