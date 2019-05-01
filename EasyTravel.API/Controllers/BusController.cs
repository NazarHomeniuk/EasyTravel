using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTravel.API.Models;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Services.Bus;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly ITripFinder tripFinder;

        public BusController(BusFinder busFinder)
        {
            tripFinder = busFinder;
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