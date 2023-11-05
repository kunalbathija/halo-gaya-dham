using Business.Authorization;
using Common;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace halo_gaya_dham_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationHelper _authorizationHelper;
        private readonly ILogger<AuthorizationController> _logger;

        public AuthorizationController
            (IAuthorizationHelper authorizationHelper,
            ILogger<AuthorizationController> logger)
        {
            _authorizationHelper = authorizationHelper;
            _logger = logger;
        }

        [HttpPost("InsertNewUser")]
        public IActionResult InsertNewUser(UserCredentials userCredentials)
        {
            try
            {
                string username = userCredentials.Username;
                string password = userCredentials.Password;

                _authorizationHelper.AddNewUser(username, password);

                _logger.LogInformation($"New user added, {username}");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AuthorizationController in InsertNewUser, {ex.Message}");
                return BadRequest(ConstantMessages.ErrorMessage);
            }
            
        }

        [HttpPost("login")]
        public IActionResult Login(UserCredentials userCredentials )
        {
            try
            {
                string username = userCredentials.Username;
                string password = userCredentials.Password;

                var loginDetails = _authorizationHelper.Login(username, password);

                if (loginDetails.isUser && loginDetails.doesPasswordMatch)
                {
                    HttpContext.Session.SetString("username", username);
                    _logger.LogInformation($"{username} Logged in successfully");
                    return Ok("User logged in successfully.");
                }
                else
                {
                    var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                    _logger.LogInformation($"{ipAddress} Someone tried unauthorized access Username : {username} Password : {password}");
                    return Unauthorized("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AuthorizationController in Login, {ex.Message}");
                return BadRequest(ConstantMessages.ErrorMessage);
            }
            
        }

        [HttpGet("ValidateUser")]
        [CustomAuthorization]
        public IActionResult ValidateUser()
        {
            var username = HttpContext.Session.GetString("username");
            if (username != null)
            {
                return Ok($"User {username} is logged in.");
            }
            else
            {
                return Unauthorized("User not logged in.");
            }
        }
    }
}
