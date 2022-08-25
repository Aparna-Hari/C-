using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
namespace ChefsNDishes.Controllers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class ChefController : Controller
{
    private ChefsNDishesContext _context;
    
    // here we can "inject" our context service into the constructor
    public ChefController(ChefsNDishesContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult All()
    {
        List<Chef> allChefs = _context.Chefs.Include(dish => dish.CreatedDishes).ToList();
            
        return View("AllChefs", allChefs);
    }

    [HttpGet("/new")]
    public  IActionResult NewChef()
    {
        return View("NewChef");
    }


    [HttpPost("/new/chef")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid == false)
        {
            return NewChef();
        }
        _context.Chefs.Add(newChef);
        _context.SaveChanges();
        return RedirectToAction("All");
    }
}