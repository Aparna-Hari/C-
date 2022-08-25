using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
namespace BeltExam.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



public class HobbyController : Controller
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

    public HobbyController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/hobbies")]//restful routing
    public IActionResult AllHobbies()
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        List<Hobby> AllHobbies = _context.Hobbies
            .Include(a => a.EnthusiasmList)
            .ToList();
        return View("AllHobbies", AllHobbies);
    }


    [HttpGet("/hobby/new")]
    public IActionResult NewHobby()
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        return View("NewHobby");
    }


    [HttpPost("/hobby/create")]
    public IActionResult Create(Hobby hobby)
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        if (ModelState.IsValid == false)
        {
            return NewHobby();
        }
        hobby.CreatorId = (int)uid;
        _context.Hobbies.Add(hobby);
        _context.SaveChanges();
        return RedirectToAction("AllHobbies");
    }

    [HttpGet("/hobby/{hobbyId}")]
    public IActionResult OneHobby(int hobbyId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        Hobby? hobby = _context.Hobbies
            .Include(e => e.EnthusiasmList)
            .ThenInclude(e => e.User)
            .FirstOrDefault(h => h.HobbyId == hobbyId);
        if (hobby == null)
        {
            return RedirectToAction("AllHobbies");
        }
        return View("OneHobby", hobby);
    }

    [HttpGet("/hobby/{hobbyId}/enthusiast")]
    public IActionResult Enthusiast(int hobbyId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("LoginRegister", "User");
        }
        EnthusiastList? currentEnthusiast = _context.EnthusiastList.FirstOrDefault(e => e.HobbyId == hobbyId && e.UserId == uid);
        if (currentEnthusiast == null)
        {
            EnthusiastList newEnthusiast = new EnthusiastList()
            {
                HobbyId = hobbyId,
                UserId = (int)uid
            };
            _context.EnthusiastList.Add(newEnthusiast);
        }
        else
        {
            // no-op
        }
        _context.SaveChanges();
        return RedirectToAction("AllHobbies");
    }
}