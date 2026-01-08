using FastKart.Abstraction;
using FastKart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FastKart.Controllers
{
    public class HomeController(IEmailService _emailService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            await _emailService.SendEmailAsync("chinarankh-mpa101@code.edu.az", "MPA-101", "<h1 style='color:red'> Email service is done</h1>");
            return Ok("Ok");
        }



    }
}
