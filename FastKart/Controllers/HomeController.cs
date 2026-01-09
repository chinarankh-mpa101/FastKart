using FastKart.Abstraction;
using FastKart.Contexts;
using FastKart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FastKart.Controllers
{
    public class HomeController(IEmailService _emailService,AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Test()
        {
            await _emailService.SendEmailAsync("chinarankh-mpa101@code.edu.az", "MPA-101", "<h1 style='color:red'> Email service is done</h1>");
            return Ok("Ok");
        }



    }
}
