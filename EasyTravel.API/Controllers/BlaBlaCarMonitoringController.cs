using System;
using System.Threading.Tasks;
using EasyTravel.API.ViewModels.Monitoring;
using EasyTravel.Contracts.Interfaces.Services.HangFire;
using EasyTravel.Core.Models.Identity;
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
        private readonly IBlaBlaCarMonitoringService monitoringService;
        private readonly UserManager<User> userManager;

        public BlaBlaCarMonitoringController(IBlaBlaCarMonitoringService monitoringService, UserManager<User> userManager)
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
        public async Task<IActionResult> Create(BlaBlaCarMonitoringViewModel viewModel)
        {
            var user = await userManager.GetUserAsync(User);
            await monitoringService.StartMonitoring(viewModel.From, viewModel.To, viewModel.DepartureDate,
                viewModel.MinPlaces, user.Id);
            return Ok();
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove(string guid)
        {
            try
            {
                await monitoringService.StopMonitoring(guid);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}