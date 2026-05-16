using interbank_app.Models;
using interbank_domain.Auth.Models;
using interbank_domain.Auth.Repositories;
using interbank_domain.Errors;
using Microsoft.AspNetCore.Mvc;

namespace interbank_app.Controllers
{
    [ApiController]
    [Route("api/auth/authentication")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepository _auth;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthenticationRepository auth, ILogger<AuthController> logger)
        {
            _auth = auth;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest body)
        {
            try
            {
                return Ok(_auth.Login(body));
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AuthenticationController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AuthenticationController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}
