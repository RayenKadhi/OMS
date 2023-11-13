using OMS.Interfaces;
using OMS.Entities;
using Dapper;
using System.Data;


namespace OMS.Data
{
    public class CustomerService : ICustomerService
    {
        private readonly IDapperService _dapperService;
        public CustomerService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        public Task<int> Create(Customer customer)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("CustomerName", customer.CustomerName, DbType.String);
            dbPara.Add("Address", customer.Address, DbType.String);
            dbPara.Add("Mobile", customer.Mobile, DbType.String);
            dbPara.Add("Email", customer.Email, DbType.String);
            var CustomerId = Task.FromResult
               (_dapperService.Insert<int>("[dbo].[spAddCustomer]",
               dbPara, commandType: CommandType.StoredProcedure));
            return CustomerId;
        }
        public Task<Customer> GetById(int id)
        {
            var customer = Task.FromResult
               (_dapperService.Get<Customer>
               ($"select * from [Customer] where CustomerId = {id}", null,
               commandType: CommandType.Text));
            return customer;
        }
        public Task<int> Delete(int id)
        {
            var deleteCustomer = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Customer] where CustomerId = {id}", null,
               commandType: CommandType.Text));
            return deleteCustomer;
        }
        public Task<int> Count()
        {
            var totCustomer = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Customer]", null,
   
               commandType: CommandType.Text));
            return totCustomer;
        }
        public Task<List<Customer>> ListAll(
         string orderBy, string direction = "DESC", string search = "")
        {
            var customers = Task.FromResult
               (_dapperService.GetAll<Customer>
               ($"SELECT * FROM [Customer] WHERE CustomerName like'%{search}%' ORDER BY { orderBy} { direction}; ", null, commandType: CommandType.Text));
           return customers;
        }
        public Task<int> Update(Customer customer)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("CustomerId", customer.CustomerId);
            dbPara.Add("CustomerName", customer.CustomerName, DbType.String);
            dbPara.Add("Address", customer.Address, DbType.String);
            dbPara.Add("Mobile", customer.Mobile, DbType.String);
            dbPara.Add("Email", customer.Email, DbType.String);
            var updateCustomer = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdateCustomer]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updateCustomer;
        }
        public Task<List<Customer>> FetchAll()
        {
            var customers = Task.FromResult
                (_dapperService.GetAll<Customer>
                ($"SELECT * FROM [Customer] ORDER BY CustomerName;",
                null, commandType: CommandType.Text));
            return customers;
        }
    }
}