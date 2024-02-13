using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;
using System.Diagnostics;

namespace SoftUniBazar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return View();

            }
            return Redirect("Ad/All");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}