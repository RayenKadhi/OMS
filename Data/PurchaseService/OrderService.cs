using OMS.Interfaces;
using OMS.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using OMS.Interfaces;
using Radzen.Blazor.Rendering;
using System.Globalization;

namespace OMS.Data
{
    public class OrderService : IOrderService
    {
        private readonly IDapperService _dapperService;
        public OrderService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        public Task<int> Create(Order order)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("CustomerId", order.CustomerId, DbType.Int64);
            dbPara.Add("OrderDate", order.OrderDate, DbType.DateTime);
            var OrderId = Task.FromResult
               (_dapperService.Insert<int>("[dbo].[spAddOrder]",
               dbPara, commandType: CommandType.StoredProcedure));
            return OrderId;
        }
        public Task<Order> GetById(int id)
        {
            var order = Task.FromResult
               (_dapperService.Get<Order>
               ($"select * from [Order] where OrderId = {id}", null,
               commandType: CommandType.Text));
            return order;
        }
        public Task<int> Delete(int id)
        {
            var deleteOrder = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Order] where OrderId = {id}", null,
               commandType: CommandType.Text));
            return deleteOrder;
        }
         public Task<int> Count(string search)
        {
            var totOrder = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Order] WHERE CustomerId like '%{search}%'", null,

               commandType: CommandType.Text));
            return totOrder;
        } 
        public Task<int> Update(Order order)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("OrderId", order.OrderId);
            dbPara.Add("CustomerId", order.CustomerId, DbType.Int64);
            dbPara.Add("OrderDate", order.OrderDate, DbType.DateTime);
 
            var updateOrder = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdateOrder]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updateOrder;
        }
        public Task<List<OrderCustomer>> ListAll()
        {
            var orders = Task.FromResult(_dapperService.
                GetAll<OrderCustomer>($"SELECT OrderId, CustomerName, OrderDate\r\nFROM [Order]\r\nLEFT JOIN Customer ON Customer.CustomerId = [Order].CustomerId ORDER BY CustomerName",null,
                commandType: CommandType.Text));
            return orders;
        }

        public Task<List<OrderDetails>> ListOrderDetailsPerCus( int OrderId)
        {
            var orderDetails = Task.FromResult(_dapperService
    .GetAll<OrderDetails>($"SELECT ProductName, UnitPrice, Quantity, Quantity * UnitPrice AS TotalPrice FROM OrderDetails LEFT JOIN Product ON Product.ProductId = OrderDetails.ProductId WHERE OrderId = {OrderId};", null, commandType: CommandType.Text));
            return orderDetails;
        }
       


    }
}