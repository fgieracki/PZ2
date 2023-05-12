using System.Diagnostics;
using filip.Data;
using Microsoft.AspNetCore.Mvc;
using filip.Models;

namespace filip.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult Login(string? email, string? password)
    {

        if (!Data.Database.TryLogin(email, password))
        {
            ViewData["Error"] = "Wrong email or password";
            return Redirect("/?Error=Invalid_data");
        }
        HttpContext.Session.SetString("email", email!);
        return Redirect("/home/success");
    }
    
    public IActionResult Success()
    {
        if (HttpContext.Session.GetString("email") == null)
            return Redirect("/?Error=401");
                
        ViewData["email"] = HttpContext.Session.GetString("email");
        // ViewData["hash"] = MD5Generator.GenerateMD5Hash("admin");
        ViewData["records"] = Data.Database.ListRecords();
        return View("Success");
    }
    
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("email");
        return Redirect("/");
    }
    
    [HttpPost]
    public IActionResult Insert(string content)
    {
        Data.Database.Insert(HttpContext.Session.GetString("email")!, content);
        return Redirect("/Home/Success");
    }
}
