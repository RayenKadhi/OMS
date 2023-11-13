using OMS.Entities;
namespace OMS.Interfaces
{
    public interface IOrderService
    {
        Task<int> Create(Order order);
        Task<int> Delete(int OrderId);
        Task<int> Count(string search);
        Task<int> Update(Order order);
        Task<Order> GetById(int OrderId);
        Task<List<OrderCustomer>> ListAll();
        Task<List<OrderDetails>> ListOrderDetailsPerCus(int OrderId);
    }
} 