using Microsoft.AspNetCore.Mvc;

namespace ElnetFirstAct.Controllers
{
    public class FBController : Controller
    {
        public IActionResult Login()
        {
            return PartialView("Login");
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
