using System.ComponentModel.DataAnnotations;
namespace OMS.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public byte Available { get; set; }
        public decimal UnitPrice { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public int Threshold { get; set; }
        public string Picture { get; set; }
    }
} 

