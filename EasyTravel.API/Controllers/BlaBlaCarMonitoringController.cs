using System.Threading.Tasks;
using EasyTravel.API.ViewModels;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Models.Identity;
using EasyTravel.HangFire.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlaBlaCarMonitoringController : ControllerBase
    {
        private readonly IMonitoringService monitoringService;
        private readonly UserManager<User> userManager;

        public BlaBlaCarMonitoringController(BlaBlaCarMonitoringService monitoringService, UserManager<User> userManager)
        {
            this.monitoringService = monitoringService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(MonitoringViewModel viewModel)
        {
            var user = await userManager.GetUserAsync(User);
            await monitoringService.StartMonitoring(viewModel.From, viewModel.To, viewModel.DepartureDate, user.Id);
            return Ok();
        }
    }
}