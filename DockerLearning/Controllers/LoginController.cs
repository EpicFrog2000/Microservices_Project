using Microsoft.AspNetCore.Mvc;

namespace DockerLearning.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
