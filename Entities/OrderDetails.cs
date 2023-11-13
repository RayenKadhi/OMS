using System.ComponentModel.DataAnnotations;
namespace OMS.Entities
{
    public class OrderDetails : Product
    {
        [Key]
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}