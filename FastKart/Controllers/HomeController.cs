using System.Diagnostics;
using FastKart.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastKart.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
