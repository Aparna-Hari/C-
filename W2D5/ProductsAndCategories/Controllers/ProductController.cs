using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
namespace ProductsAndCategories.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


public class ProductController : Controller
{

    private MyContext _context;

    public ProductController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/products")]
    public IActionResult Products()
    {
        List<Product> AllProducts = _context.Products.ToList();
        ViewBag.Products = AllProducts;
        return View("AllProducts");
    }

    [HttpPost("/product/new")]
    public IActionResult NewProduct(Product newProduct)
    {
        if(ModelState.IsValid == false)
        {
            return Products();
        }
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Products");
    }

    [HttpGet("/products/{productId}")]
    public IActionResult CatOfProd(int productId)
    {
        Product? OneProduct = _context.Products
            .Include(p => p.ProductsWithCategories)
            .ThenInclude(c => c.Category)
            .FirstOrDefault(p => p.ProductId == productId);
        ViewBag.Product = OneProduct;

        ViewBag.NotYetAssoc = _context.Categories
            .Include(p => p.CategoriesWithProducts)
            .ThenInclude(p => p.Product)
            .Where(c => !c.CategoriesWithProducts.Any(c => c.ProductId == productId));
        return View("CategoriesOfProducts");
    }

    [HttpPost("/product/addcategory/{productId}")]
    public IActionResult AddCategory(int productId, Association newCategory)
    {
        if(ModelState.IsValid == false)
        {
            return CatOfProd(productId);
        }
        newCategory.ProductId = productId;
        _context.Associations.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("CatOfProd", new {productId = productId});
    }
}