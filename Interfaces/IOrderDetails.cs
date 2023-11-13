using OMS.Entities;
namespace OMS.Interfaces
{
    public interface IOrderDetails
    {
        Task<int> Create(OrderDetails orderDetails);
        Task<int> Delete(int CustomerId);
        Task<int> Count(string search);
        Task<int> Update(OrderDetails orderDetails);
        Task<OrderDetails> GetById(int OrderId);
        Task<List<OrderDetails>> ListAll(int skip, int take,
            string orderBy, string direction, string search);
    }
}