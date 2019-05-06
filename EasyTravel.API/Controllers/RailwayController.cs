using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTravel.API.ViewModels;
using EasyTravel.Contracts.Interfaces.Core;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Services.Railway;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RailwayController : ControllerBase
    {
        private readonly ITripFinder tripFinder;

        public RailwayController(RailwayFinder railwayFinder)
        {
            tripFinder = railwayFinder;
        }

        [HttpPost]
        [Route("find")]
        public async Task<IEnumerable<ITrip>> Find(RequestViewModel requestViewModel)
        {
            return await tripFinder.FindTripsAsync(requestViewModel.From, requestViewModel.To, requestViewModel.Date);
        }

        [HttpPost]
        [Route("findAll")]
        public async Task<IEnumerable<ITrip>> FindAll(RequestViewModel requestViewModel)
        {
            return await tripFinder.FindAllTripsAsync(requestViewModel.From, requestViewModel.To, requestViewModel.Date);
        }
    }
}