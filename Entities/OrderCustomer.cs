using System.ComponentModel.DataAnnotations;
namespace OMS.Entities
{
    public class OrderCustomer : Order
    {
        public string CustomerName { get; set; }
    }
}