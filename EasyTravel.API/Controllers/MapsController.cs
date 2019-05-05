using System.Collections.Generic;
using System.Threading.Tasks;
using EasyTravel.Contracts.Interfaces;
using EasyTravel.Contracts.Interfaces.Services;
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
        [Route("between")]
        public async Task<IEnumerable<string>> Between(string from, string to)
        {
            return await mapsService.FindLocationsBetweenAsync(from, to);
        }
    }
}