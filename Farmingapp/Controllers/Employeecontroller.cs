// EmployeeController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = nameof(Roles.Employee))]
public class EmployeeController : Controller
{
    private readonly AgriEnergyContext _context;

    public EmployeeController(AgriEnergyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Farmers.ToList());
    }

    public IActionResult AddFarmer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddFarmer(Farmer farmer)
    {
        if (ModelState.IsValid)
        {
            _context.Farmers.Add(farmer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(farmer);
    }

    public IActionResult ViewProducts(int farmerID)
    {
        var products = _context.Products.Where(p => p.FarmerID == farmerID);
        return View(products);
    }
}