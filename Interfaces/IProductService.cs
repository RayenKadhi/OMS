using OMS.Entities;
namespace OMS.Interfaces
{
    public interface IProductService
    {
        Task<int> Create(Product product);
        Task<int> Delete(int ProductId);
        Task<int> Count();
        Task<int> Update(Product product);
        Task<Product> GetById(int ProductId);
        Task<List<Product>> ListAll(string orderBy, string direction, string search);
    }
}