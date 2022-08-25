using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
namespace ChefsNDishes.Controllers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class DishController : Controller
{
    private ChefsNDishesContext _context;
    
    // here we can "inject" our context service into the constructor
    public DishController(ChefsNDishesContext context)
    {
        _context = context;
    }

    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        List<Dish> allDishes = _context.Dishes.Include(chef => chef.Chef).ToList();
            
        return View("AllDishes", allDishes);
    }

    [HttpGet("dishes/new")]
    public  IActionResult NewDish()
    {
        List<Chef> allChefs = _context.Chefs.ToList();
        ViewBag.overall = allChefs;
        return View("NewDIsh");
    }


    [HttpPost("/new/dish")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid == false)
        {
            return NewDish();
        }
        _context.Dishes.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Dishes");
    }
}