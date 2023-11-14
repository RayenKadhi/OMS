using OMS.Entities;
namespace OMS.Interfaces
{
    public interface ICustomerService
    {
        Task<int> Create(Customer customer);
        Task<int> Delete(int CustomerId);
        Task<int> Count();
        Task<int> Update(Customer customer);
        Task<Customer> GetById(int CustomerId);
        Task<List<Customer>> ListAll(
          string orderBy, string direction, string search);
        Task<List<Customer>> FetchAll();
		Task<Customer> GetByIdDetail(int CustomerId);
		
	}
}