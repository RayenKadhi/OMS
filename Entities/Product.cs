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
    }
}