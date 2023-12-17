using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ESPDumpsterWebApp.Models;
using ESPDumpsterWebApp.Data;

namespace ESPDumpsterWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Service()
    {
        return View();
    }
    
    public IActionResult Why()
    {
        return View();
    }
    
    public IActionResult Team()
    {
        return View();
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