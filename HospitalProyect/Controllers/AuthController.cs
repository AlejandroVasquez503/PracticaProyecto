using HospitalProyect.Models;
using HospitalProyect.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProyect.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthRepository _authRepository;
        
        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel userModel)
        {
            
            if (ModelState.IsValid)
            {
                bool isRegistered = _authRepository.RegisterUser(userModel);

                if (isRegistered)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewBag.Error = "Registration failed. Please try again.";
                }
            }

            return View(userModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and password are required.";
                return View();
            }

            var user = _authRepository.ValidateUser(email, password);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid email or password.";
            }

            ViewBag.Error = "Invalid email or password.";
            return View();
        }

    }
}
