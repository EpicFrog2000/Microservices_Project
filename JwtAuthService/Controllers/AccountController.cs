using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace JwtAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public AccountController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] AuthenticationRequest authenticationRequest)
        {
            var authResult = _jwtAuthenticationManager.Authenticate(authenticationRequest.UserName, authenticationRequest.Password);
            if (authResult == null)
                return Unauthorized();
            else
                return Ok(authResult);
        }

        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return "xd";
        }
    }
}
