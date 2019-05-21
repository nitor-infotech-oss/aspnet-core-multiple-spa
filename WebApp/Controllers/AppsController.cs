using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AppsController : Controller
    {
        // GET: /<controller>/
        public IActionResult App1()
        {
            return View();
        }

        public IActionResult App2()
        {
            return View();
        }
    }
}