using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPasscodeGen.Models;

namespace RandomPasscodeGen.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        int? count = HttpContext.Session.GetInt32("Count");

        if (count == null)
        {
            HttpContext.Session.SetInt32("Count",0);
        }
        string? code = HttpContext.Session.GetString("Passcode");

        if(code == null){
            HttpContext.Session.SetString("Passcode", "Let's get a New Code!");
        }
        // ViewBag.Count = count;
        // ViewBag.Passcode = code;
        return View();
    }


    [HttpPost("/newCode")]
    public IActionResult NewPasscode()
    {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randChars = "";
            Random rand = new Random();
            for(int i = 0; i < 14; i++)
            {
                randChars+=(chars[rand.Next(chars.Length)]);
            }

            int? count = HttpContext.Session.GetInt32("Count");
            if(count != null)
            {
                count++;
                HttpContext.Session.SetInt32("Count", (int)count);
                HttpContext.Session.SetString("Passcode", randChars);
            }
            return RedirectToAction("Index");
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
