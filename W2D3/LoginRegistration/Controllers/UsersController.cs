using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
namespace LoginRegistration.Controllers;



public class UsersController: Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    
    private UserContext _context;

    public UsersController (UserContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    public  IActionResult Index()
    {
        if(loggedIn)
        {
            return Success();
        }
        return View("Register");
    }

    [HttpPost("/Register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "already exists");
            }
        }
        if (ModelState.IsValid == false)
        {
            return View("Register");
        }
        PasswordHasher<User> HashedPw = new PasswordHasher<User>();
        newUser.Password =HashedPw.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();

        HttpContext.Session.SetInt32("UID", newUser.UserId);

        return RedirectToAction("Login");
        
    }

    [HttpGet("/login")]
    public IActionResult Submit()
    {
        if(loggedIn)
        {
            return Success();
        }
        return View("Login");
    }

    [HttpPost("/Login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return View(" Register");
        }

        User? dbUser = _context.Users.FirstOrDefault(u => u.Email == loginUser.Email);

        if (dbUser == null)
        {
            ModelState.AddModelError("Email", "and Password don't match");
            return View(" Register");
        }

        PasswordHasher<LoginUser> HashedPw = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompare = HashedPw.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.Password);

        if (pwCompare == 0)
        {
            ModelState.AddModelError("Password", "doesn't match this email");
            return View(" Register");
        }

        HttpContext.Session.SetInt32("UID", dbUser.UserId);
        return RedirectToAction("Success");
    }
    [HttpGet("/success")]
    public IActionResult Success()
    {
        if(!loggedIn)
        {
            return Submit();
        }
        return View("Success");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Submit();
    }

}