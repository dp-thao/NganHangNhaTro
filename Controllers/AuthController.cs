using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using NganHangNhaTro.Models.Views;
using Microsoft.AspNetCore.Authorization;
using NganHangNhaTro.Repositories;
using NganHangNhaTro.Models;
using Microsoft.AspNetCore.Identity;

namespace NganHangNhaTro.Controllers
{
    public class AuthController : Controller
    {
        private string name = "auth";
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginView login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = _userRepository.getByUsernameAndPassword(login);
                    if (user != null)
                    {
                        // Lưu thông tin người dùng vào session hoặc cookie
                        HttpContext.Session.SetString("uid", user.id.ToString());
                        HttpContext.Session.SetString("username", user.username);
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Sai tài khoản hoặc mật khẩu!";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterView register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isSuccess = await _userRepository.create(register);
                    if (isSuccess)
                    {
                        ViewBag.RegisterMessage = "Đăng kí thành công, đăng nhập để tiếp tục.";
                        return RedirectToAction("login", name);
                    }
                    else return View(register);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View(register);
                }
            }
            return View(register);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", name);
        }
    }
}
