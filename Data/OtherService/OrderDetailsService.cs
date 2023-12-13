using OMS.Interfaces;
using OMS.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using OMS.Interfaces;

namespace OMS.Data
{
    public class OrderDetailsService : IOrderDetails
    {
        private readonly IDapperService _dapperService;
        public OrderDetailsService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        public Task<int> Create(OrderDetails orderDetails)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Quantity", orderDetails.Quantity, DbType.Int64);
      
            var id = Task.FromResult
               (_dapperService.Insert<int>("[dbo].[spAddOrderDetails]",
               dbPara, commandType: CommandType.StoredProcedure));
            return id;
        }
        public Task<OrderDetails> GetById(int id)
        {
            var orderDetails = Task.FromResult
               (_dapperService.Get<OrderDetails>
               ($"select * from [OrderDetails] where OrderId = {id}", null,
               commandType: CommandType.Text));
            return orderDetails;
        }
        public Task<int> Delete(int id)
        {
            var delete = Task.FromResult
               (_dapperService.Execute
               ($"Delete [OrderDetails] where OrderId = {id}", null,
               commandType: CommandType.Text));
            return delete;
        }
        public Task<int> Count(string search)
        {
            var totCustomer = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [OrderDetails] WHERE OrderId like '%{search}%'", null,

               commandType: CommandType.Text));
            return totCustomer;
        }
        public Task<List<OrderDetails>> ListAll(int skip, int take,
           string orderBy, string direction = "DESC", string search = "")
        {
            var Order = Task.FromResult
               (_dapperService.GetAll<OrderDetails>
               ($"SELECT * FROM [OrderDetails] WHERE OrderId like'%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return Order;
        }
        public Task<int> Update(OrderDetails orderDetails)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("OrderId", orderDetails.OrderId);
            dbPara.Add("ProductId", orderDetails.ProductId);
            dbPara.Add("Quantity", orderDetails.Quantity, DbType.Int64);
         
            var updateOrderDetail = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdateOrderDetails]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updateOrderDetail;
        }
    }
}