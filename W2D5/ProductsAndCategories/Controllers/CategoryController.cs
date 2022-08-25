using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
namespace ProductsAndCategories.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


public class CategoryController : Controller
{

    private MyContext _context;

    public CategoryController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/categories")]
    public IActionResult Categories()
    {
        List<Category> AllCategories = _context.Categories.ToList();
        ViewBag.Categories = AllCategories;
        return View("AllCategories");
    }


    [HttpPost("/category/new")]
    public IActionResult NewCategory(Category newCategory)
    {
        if(ModelState.IsValid == false)
        {
            return Categories();
        }
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("Categories");
    }


    [HttpGet("/categories/{categoryId}")]
    public IActionResult ProdOfCat(int categoryId)
    {
        Category? EachCategory = _context.Categories.Include(c => c.CategoriesWithProducts)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(c => c.CategoryId == categoryId);

            ViewBag.Category = EachCategory;
            ViewBag.NotYetAssoc = _context.Products
            .Include(c => c.ProductsWithCategories)
            .ThenInclude(c => c.Category)
            .Where(c => !c.ProductsWithCategories.Any(p => p.CategoryId == categoryId));        
        return View("ProductsOfCategories");
    }

}