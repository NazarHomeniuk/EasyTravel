using EasyTravel.API.Models;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.HangFire.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RailwayMonitoringController : ControllerBase
    {
        private readonly IMonitoringService monitoringService;

        public RailwayMonitoringController(RailwayMonitoringService monitoringService)
        {
            this.monitoringService = monitoringService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(MonitoringRequest request)
        {
            monitoringService.StartMonitoring(request.From, request.To, request.DepartureDate);
            return Ok();
        }
    }
}