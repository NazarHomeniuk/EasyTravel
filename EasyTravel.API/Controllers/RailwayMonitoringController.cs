using System.Threading.Tasks;
using EasyTravel.API.ViewModels.Monitoring;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Core.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyTravel.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RailwayMonitoringController : ControllerBase
    {
        private readonly IRailwayMonitoringService monitoringService;
        private readonly UserManager<User> userManager;

        public RailwayMonitoringController(IRailwayMonitoringService monitoringService, UserManager<User> userManager)
        {
            this.monitoringService = monitoringService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var user = await userManager.GetUserAsync(User);
            var monitor = await monitoringService.GetAllMonitoringForUser(user.Id);
            return Ok(monitor);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RailwayMonitoringViewModel viewModel)
        {
            var user = await userManager.GetUserAsync(User);
            await monitoringService.StartMonitoring(viewModel.From, viewModel.To, viewModel.DepartureDate,
                viewModel.PlacesType, viewModel.MinPlaces, user.Id);
            return Ok();
        }
    }
}