using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ESPDumpsterWebApp.Models;
using ESPDumpsterWebApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESPDumpsterWebApp.Controllers;

public class DashboardController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public DashboardController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult News()
    {
        return View();
    }
    
    public IActionResult Notifications()
    {
        return View();
    }
    
    public IActionResult Feedback()
    {
        return View();
    }
    
    public IActionResult AuthenticationLogin()
    {
        return View();
    }
    
    public IActionResult AuthenticationRegister()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}