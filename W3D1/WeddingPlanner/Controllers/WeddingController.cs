using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
namespace WeddingPlanner.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class WeddingController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    } 
    private MyContext _context;

    public WeddingController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/dashboard")]//restful routing
    public IActionResult Dashboard()
    {
        if(!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        List<Wedding> AllWeddings = _context.Weddings
            .Include(a => a.AttendanceList)
            .ToList();
        return View("Dashboard", AllWeddings);
    }  


    [HttpGet("/wedding/new")]
    public IActionResult NewWedding()
    {
        if(!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        return View("NewWedding");
    }



    [HttpGet("/{weddingId}")]
    public IActionResult WeddingDetails(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        Wedding? wedding = _context.Weddings
            .Include(g => g.AttendanceList)
            .ThenInclude(a => a.User)
            .FirstOrDefault(w => w.WeddingId == weddingId);
        
        if(wedding == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View("WeddingDetails", wedding);
    }

    [HttpGet("/delete/{weddingId}")]
    public IActionResult DeleteOne(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        Wedding? wedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
        if(wedding == null)
        {
            return RedirectToAction("Dashboard");
        }

        _context.Weddings.Remove(wedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/wedding/{weddingId}/participate")]
    public IActionResult Participate(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        GuestList? currentGuest = _context.GuestList.FirstOrDefault(g => g.WeddingId == weddingId && g.UserId == uid);
        if(currentGuest == null)
        {
            GuestList newGuest = new GuestList()
            {
                WeddingId = weddingId,
                UserId = (int)uid
            };
            _context.GuestList.Add(newGuest);
        }
        else
        {
            _context.Remove(currentGuest);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }


    [HttpPost("/wedding/create")]
    public IActionResult Create(Wedding wedding)
    {
        if(!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        if(ModelState.IsValid == false)
        {
            return NewWedding();
        }
        wedding.PlannerId = (int)uid;
        _context.Weddings.Add(wedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/wedding/{weddingId}")]
    public IActionResult OneWedding(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        Wedding? wedding = _context.Weddings
            .Include(g => g.AttendanceList)
            .ThenInclude(g => g.User)
            .FirstOrDefault(w => w.WeddingId == weddingId);
        if(wedding == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View("OneWedding", wedding);
    }

}