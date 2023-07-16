using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using NganHangNhaTro.Models.Views;
using Microsoft.AspNetCore.Authorization;
using NganHangNhaTro.Repositories;
using NganHangNhaTro.Models;

namespace NganHangNhaTro.Controllers
{
    public class MotelController : Controller
    {
        private string name = "motel";
        private IMotelRepository _motelRepository;

        public MotelController(IMotelRepository motelRepository)
        {
            _motelRepository = motelRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
