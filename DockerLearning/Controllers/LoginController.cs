
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

        [HttpGet("AdminPage")]
        public IActionResult AdminPage()
        {
            string tokenValue = null;
            try
            {
                tokenValue = HttpContext.Request.Cookies["token"];
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            if (string.IsNullOrEmpty(tokenValue))
            {
                // If token is not present, redirect to the Login page
                return RedirectToAction("Login");
            }
            else
            {
                // Otherwise, return the AdminPage view
                return View();
            }
        }

    }
}
