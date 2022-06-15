using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

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
        List<Dish> allDishes = _context.Dishes.ToList();
        return View("All",allDishes);
    }



    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }



    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid == false)
        {
            //If  validation is false, we will send the user back to the create new dish page
            return New();
        }
        //Only runs if Modelstate is valid
        _context.Dishes.Add(newDish);

        //Context doesnt update until we run SaveChanges
        //After savechanges 
        _context.SaveChanges();

        return RedirectToAction("All");
    }


    [HttpGet("/dishes/{dishId}")]
    public IActionResult Details(int dishId)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId ==dishId);

        if(dish == null)
        {
            return RedirectToAction("All");
        }
        return View(dish);
    }

    [HttpGet("/dishes/edit/{dishId}")]
    public IActionResult Edit(int dishId)
    {
        Dish? dish =_context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if(dish != null )
        {
            return View("Edit",dish);
        }
        return RedirectToAction("All");
    }


    [HttpPost("/dishes/delete/{dishId}")]
    public IActionResult Delete(int dishId)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        if (dish != null)
        {
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }

        return RedirectToAction("All");
    }


    [HttpPost("/dishes/{dishId}/update")]
    public IActionResult Update(Dish editedDish, int dishId)
    {
        if(ModelState.IsValid)
        {
            Dish? dbDish =_context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if (dbDish != null)
            {
                dbDish.Name = editedDish.Name;
                dbDish.Chef = editedDish.Chef;
                dbDish.Tastiness = editedDish.Tastiness;
                dbDish.Calories = editedDish.Calories;
                //dbDish.UpdatedAt = editedDish.UpdatedAt;

                _context.Dishes.Update(dbDish);
                _context.SaveChanges();

                
            }

            return RedirectToAction("Details",dishId);
        }
        else
        {
            return Edit(dishId);
        }
    }
}