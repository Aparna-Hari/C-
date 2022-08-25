using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;    //be sure to use your own project's namespace!

namespace ViewModelFun.Controllers;
    public class HomeController : Controller   // inheritance
    {
        

        public IActionResult Index()
        {
            string message = "Lorem Ipsum...";
            return View("Index",message);
        }

        [HttpGet("Numbers")]
        public IActionResult Numbers()
        {
            int[] numerals = new int[]
            {
                1,
                2,
                3,
                10,
                43,
                5
            };
            return View(numerals);
        }

        [HttpGet("Users")]
        public IActionResult Users()
        {
            List<User> users = new List<User>();
            users.Add(new User("Moose","Phillips"));
            users.Add(new User("Sarah"));
            users.Add(new User("Jerry"));
            users.Add(new User("Rene","Ricky"));
            users.Add(new User("Barbarah"));

            return View(users);
        }

        [HttpGet("User")]
        public IActionResult OneUser()
        {
            User firstUser = new User("Moose","Phillips");
            return View(firstUser);
        }

    }