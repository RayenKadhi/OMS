using Dapper;
using OMS.Entities;
using System.Data.Common;

using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;

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
    public interface IUserService
    {
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<List<User>> ListAll();
        Task<User> GetById(int UserId);
        Task<int> Count();
    }

        public interface IProductService 
    {
        Task<int> Create(Product product);
        Task<int> Delete(int ProductId);
        Task<int> Count();
        Task<int> Update(Product product);
        Task<Product> GetById(int ProductId);
        Task<List<Product>> ListAll(string orderBy, string direction, string search);
        Task<Product> GetByIdDetail(int ProductId);
        Task<Product> GetCategoryByName(string CategoryName);
       
    }
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
    public interface IBrandService
    {
        Task<int> Create(Brand brand);
        Task<int> Delete(int brand);
        Task<int> Update(Brand brand);
        Task<List<Brand>> ListAll(
        string orderBy, string direction, string search);
        Task<int> Count();

    }
    public interface ICategoryService
    {
        Task<int> Create(Category category);
        Task<int> Delete(int category);
        Task<int> Update(Category category);
        Task<List<Category>> ListAll(
        string orderBy, string direction, string search);
        Task<int> Count();
    }
    public interface IDapperService : IDisposable
    {
        DbConnection GetConnection();
        T Get<T>(string sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms,
           CommandType commandType = CommandType.Text);
        int Execute(string sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);
        T ExecuteScalar<T>(string query, DynamicParameters parameters = null,
           CommandType commandType = CommandType.Text);
        T Update<T>(string sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);
    }
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
    public interface IPriceFormattingService
    {
        string FormatPrice(decimal price, string currencyCode);
        string FormatPrice(double price, string currencyCode);
    }
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
