using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;

namespace ModernPortfolio.Controllers
{
    public class AccountController : Controller
    {
        // Login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Process login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.Username == "admin" &&
                model.Password == "admin123")
            {
                HttpContext.Session.SetString("LoggedIn", "true");

                return RedirectToAction("Index", "Portfolio");
            }

            ViewBag.Error = "Invalid username or password.";

            return View(model);
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}