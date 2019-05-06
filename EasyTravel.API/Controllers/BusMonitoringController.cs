using EasyTravel.API.ViewModels;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.HangFire.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BusMonitoringController : ControllerBase
    {
        private readonly IMonitoringService monitoringService;

        public BusMonitoringController(BusMonitoringService monitoringService)
        {
            this.monitoringService = monitoringService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(MonitoringViewModel viewModel)
        {
            monitoringService.StartMonitoring(viewModel.From, viewModel.To, viewModel.DepartureDate);
            return Ok();
        }
    }
}