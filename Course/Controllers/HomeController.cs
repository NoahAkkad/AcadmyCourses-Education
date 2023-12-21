using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Course.Models;

namespace Course.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.welcome = "Welcome to AcadmyCourses Education";
        ViewBag.message = "Dear student, with us you can prepare yourself before admission to the university, take a look at the list of courses currently available, and if you have any questions, you can contact us.";
        //returns a viewresult
        return View("Index");
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

