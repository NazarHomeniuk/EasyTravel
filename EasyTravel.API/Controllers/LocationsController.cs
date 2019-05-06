using System.Collections.Generic;
using System.Linq;
using EasyTravel.Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public LocationsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("locations")]
        public IEnumerable<string> Locations()
        {
            var locations = dataContext.GeoNames.ToList();
            return locations.Select(s => s.AlternateNames);
        }

        [HttpGet]
        [Route("autocomplete")]
        public IEnumerable<string> Autocomplete(string prefix)
        {
            var locations = dataContext.GeoNames.ToList();
            return locations.Select(s => s.AlternateNames).Where(s => s != null && s.ToLower().StartsWith(prefix));
        }
    }
}