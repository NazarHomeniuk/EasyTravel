using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyTravel.API.ViewModels;
using EasyTravel.Core.Config;
using EasyTravel.Core.Models.Identity;
using EasyTravel.Sms.Services;
using EasyTravel.Smtp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EasyTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IdentityConfig identityConfig;
        private readonly SmtpService smtpService;
        private readonly SmsService smsService;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager,
            IOptions<IdentityConfig> options, SmtpService smtpService, SmsService smsService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.smtpService = smtpService;
            this.smsService = smsService;
            identityConfig = options.Value;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var user = await userManager.FindByEmailAsync(viewModel.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return Ok(GenerateJwtToken(viewModel.Email, user));
                }
            }

            return Forbid();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var user = new User
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
            };

            var result = await userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return Ok(GenerateJwtToken(viewModel.Email, user));
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route("currentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("verifyEmail")]
        public async Task<IActionResult> VerifyEmail()
        {
            var user = await userManager.GetUserAsync(User);
            var random = new Random();
            var code = random.Next(10000, 99999);
            smtpService.SendVerificationCode(code, user.Email);
            user.VerificationCode = code;
            await userManager.UpdateAsync(user);
            return Ok();
        }

        [HttpGet]
        [Route("verifyEmailCode")]
        public async Task<IActionResult> VerifyEmailCode(string code)
        {
            var user = await userManager.GetUserAsync(User);
            if (int.TryParse(code, out var intCode) && user.VerificationCode == intCode)
            {
                user.EmailConfirmed = true;
                await userManager.UpdateAsync(user);
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost]
        [Route("verifyNumber")]
        public async Task<IActionResult> VerifyNumber()
        {
            var user = await userManager.GetUserAsync(User);
            var random = new Random();
            var code = random.Next(10000, 99999);
            //smsService.SendVerificationCode(code, user.PhoneNumber);
            user.VerificationCode = code;
            await userManager.UpdateAsync(user);
            return Ok();
        }

        [HttpGet]
        [Route("verifyNumberCode")]
        public async Task<IActionResult> VerifyNumberCode(string code)
        {
            var user = await userManager.GetUserAsync(User);
            if (int.TryParse(code, out var intCode) && user.VerificationCode == intCode)
            {
                user.PhoneNumberConfirmed = true;
                await userManager.UpdateAsync(user);
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost]
        [Route("changeEmailNotification")]
        public async Task<IActionResult> ChangeEmailNotification()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                user.EmailNotificationEnabled = !user.EmailNotificationEnabled;
                await userManager.UpdateAsync(user);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("changeSmsNotification")]
        public async Task<IActionResult> ChangeSmsNotification()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                user.SmsNotificationEnabled = !user.SmsNotificationEnabled;
                await userManager.UpdateAsync(user);
                return Ok();
            }

            return BadRequest();
        }

        private string GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identityConfig.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(identityConfig.ExpirationDays));

            var token = new JwtSecurityToken(
                identityConfig.Issuer,
                identityConfig.Issuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}