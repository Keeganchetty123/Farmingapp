// FarmerController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = nameof(Roles.Farmer))]
public class FarmerController : Controller
{
    private readonly AgriEnergyContext _context;

    public FarmerController(AgriEnergyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var farmer = _context.Farmers.Find(User.Identity.Name);
        return View(farmer.Products);
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            product.FarmerID = _context.Farmers.Find(User.Identity.Name).FarmerID;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }
}