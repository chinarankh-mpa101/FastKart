using FastKart.Models;
using FastKart.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FastKart.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var isExistUser = await _userManager.FindByNameAsync(vm.Fullname);

            if(isExistUser is not null)
            {
                ModelState.AddModelError("Fullname", "Bu istifadeci artiq movcuddur");
                return View(vm);
            }

            isExistUser = await _userManager.FindByEmailAsync(vm.Email);
            if(isExistUser is not null)
            {
                ModelState.AddModelError("Email", "Bu istifadeci artiq movcuddur");
                return View(vm);
            }

            AppUser newUser = new()
            {
                Fullname = vm.Fullname,
                UserName=vm.Username,
                Email = vm.Email
            };

            var result= await _userManager.CreateAsync(newUser, vm.Password);

            if (!result.Succeeded)
            {
               foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm);
            }

            return Ok("Welcome");
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Login(LoginVM vm)
        {
            if(!ModelState.IsValid) 
                return View(vm);

            var user = await _userManager.FindByEmailAsync(vm.Email);
            if (user is null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(vm);
            }
            var loginResult = await _userManager.CheckPasswordAsync(user, vm.Password);
            if (!loginResult)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(vm);
            }
            await _signInManager.SignInAsync(user, vm.IsRemember);
            return Ok($"welcome {user.Fullname}");

        }

		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));

		}

	}
}
