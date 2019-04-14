using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly IMapsService mapsService;

        public MapsController(IMapsService mapsService)
        {
            this.mapsService = mapsService;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get(string from, string to)
        {
            return await mapsService.FindLocationsBetweenAsync(from, to);
        }
    }
}