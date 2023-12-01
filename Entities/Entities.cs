using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OMS.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; } = " ";
        public bool Available { get; set; } = true;
        public decimal UnitPrice { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Threshold { get; set; }
        public string Picture { get; set; } = "Images/Product.png";
        public int InitialQuantity { get; set; }
        public string Barcode { get; set; }
     
    }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
    public class OrderDetails : Product
    {
        [Key]
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
    public class OrderCustomer : Order
    {
        public string CustomerName { get; set; }
    }

    public class ProductSearch
    {
        public string ProductNameOrBarcode { get; set; }
        public List<int> SelectedCategories { get; set; } = new List<int>();
        public List<int> SelectedBrands { get; set; } = new List<int>();
        public string MinUnitPrice { get; set; }
        public string MaxUnitPrice { get; set; }
        public string MinIntialQuantity { get; set; }
        public string MaxIntialQuantity { get; set; }
        public string MaxThreshold { get; set; }
        public string MinThreshold { get; set; }
        public bool? Available { get; set; }

    }

    public class RevenueData
    {
        public DateTime OrderDate { get; set; }
        public double Revenue { get; set; }
    }
    public class RevenueYear
    {
        public string Year { get; set; }
        public double Revenue { get; set; }
    }
    public class TopFive
    {
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public byte Suspended { get; set; }  
        public string LastLoginDate { get; set; }
    }
}
