using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDDelicious.Models;

public class DishesController : Controller
{
    private CRUDContext _context;

    public DishesController (CRUDContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult All()
    {
        List<Dish> allDishes  = _context.Dishes.ToList();
        return View("All",allDishes);
    }

    [HttpGet("/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid == false)
        {
            //If  validation is false, we will send the user back to the create new dish page
            return New();
        }
        _context.Add(newDish);
        _context.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpGet("/{dishId}")]
    public IActionResult Details(int dishId)
    {
        Dish? dish= _context.Dishes.FirstOrDefault(dish => dish.DishId ==dishId);
        if(dish == null)
        {
            return RedirectToAction("All");
        }
        return View(dish);
    }

    [HttpGet("Edit/{dishId}")]
    public IActionResult Edit(int dishId)
    {
        Dish? dish =_context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if(dish != null )
        {
            return View("Edit",dish);
        }
        return RedirectToAction("All");
    }

    [HttpPost("/update/{dishId}")]
    public IActionResult UpdateDish(int dishId, Dish editedDish)
    {
        if(ModelState.IsValid)
        {
            //Returns the first element of a sequence that satisfies a specified condition or a default value if no such element is found.
            Dish? dbDish =_context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if (dbDish != null)
            {
                dbDish.Name = editedDish.Name;
                dbDish.Chef = editedDish.Chef;
                dbDish.Tastiness = editedDish.Tastiness;
                dbDish.Calories = editedDish.Calories;
                dbDish.UpdatedAt = DateTime.Now;

                _context.Dishes.Update(dbDish);
                _context.SaveChanges();

                
            }

            return RedirectToAction("All", dishId);
        }
        else
        {
            return Edit(dishId);
        }
    }

    [HttpGet("delete/{dishId}")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        if (dish != null)
        {
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }

        return RedirectToAction("All");
    }
}