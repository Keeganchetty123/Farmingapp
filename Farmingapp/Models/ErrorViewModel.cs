// Farmer.cs
public class Farmer
{
    public int FarmerID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Product> Products { get; set; }
}

// Product.cs
public class Product
{
    public int ProductID { get; set; }
    public int FarmerID { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public DateTime ProductionDate { get; set; }
    public Farmer Farmer { get; set; }
}

// Models/ErrorViewModel.cs
namespace Farmingapp.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}