using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Models;
using NganHangNhaTro.Repositories;

namespace NganHangNhaTro.Controllers;

public class HomeController : Controller
{
    private IMotelRepository _motelRepository;

    public HomeController(IMotelRepository motelRepository)
    {
        _motelRepository = motelRepository;
    }

    public IActionResult Index(string title)
    {
        // int pageSize = 10; // Số lượng mục hiển thị trên mỗi trang
        // int totalItems = _motelRepository.getAll(title).Count; // Tổng số lượng mục
        List<Motel> motels = _motelRepository.GetAll(title);
        return View(motels);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
