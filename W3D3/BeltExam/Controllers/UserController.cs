using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
namespace BeltExam.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class UserController: Controller
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

    private MyContext  _context;

    public UserController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult LoginRegister()
    {
        if(loggedIn)
        {
            return RedirectToAction("AllHobbies","Hobby");
        }
        return View("LoginRegister");
    }


    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        
            if(_context.Users.Any(a => a.UserName == newUser.UserName))
            {
                ModelState.AddModelError("UserName", "is taken");
                //return LoginRegister();
            }

        if(ModelState.IsValid == false)
        {
            return LoginRegister();
        }

        PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
        newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);

        _context.Users.Add(newUser);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("name", newUser.FullName());
        return RedirectToAction("AllHobbies","Hobby");
    }


    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if(ModelState.IsValid == false)
        {
            return LoginRegister();
        }

        User? dbUser = _context.Users.FirstOrDefault(a => a.UserName == loginUser.LoginUserName);

        if(dbUser == null)
        {
            ModelState.AddModelError("LoginUserName", "not found");
            return LoginRegister();
        } 

        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCheck = hashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if(pwCheck == 0)
        {
            ModelState.AddModelError("LoginPassword", "is invalid");
            return LoginRegister();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        HttpContext.Session.SetString("name", dbUser.FullName());
        return RedirectToAction("AllHobbies","Hobby");
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LoginRegister");
    }
}