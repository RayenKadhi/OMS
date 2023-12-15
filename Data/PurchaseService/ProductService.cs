﻿using OMS.Interfaces;
using OMS.Entities;
using Dapper;
using System.Data;


namespace OMS.Data
{
    public class ProductService : IProductService
    {
        private readonly IDapperService _dapperService;
        public ProductService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        public Task<int> Create(Product product)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ProductName", product.ProductName, DbType.String);
            dbPara.Add("Description", product.Description, DbType.String);
            dbPara.Add("Available", product.Available, DbType.Byte);
            dbPara.Add("UnitPrice", product.UnitPrice, DbType.Decimal);
            dbPara.Add("CategoryId", product.CategoryId, DbType.Int64);
            dbPara.Add("BrandId", product.BrandId, DbType.Int64);
            dbPara.Add("Threshold", product.Threshold, DbType.Int64);
            dbPara.Add("Picture", product.Picture, DbType.String);
            var ProductId = Task.FromResult
               (_dapperService.Insert<int>("[dbo].[spAddProduct]",
               dbPara, commandType: CommandType.StoredProcedure));
            return ProductId;
        }
        public Task<Product> GetById(int id)
        {
            var product = Task.FromResult
               (_dapperService.Get<Product>
               ($"select * from [Product] where ProductId = {id}", null,
               commandType: CommandType.Text));
            return product;
        }
        public Task<int> Delete(int id)
        {
            var deleteProduct = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Product] where ProductId = {id}", null,
               commandType: CommandType.Text));
            return deleteProduct;
        }
        public Task<int> Count()
        {
            var totProduct = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Product]", null,

               commandType: CommandType.Text));
            return totProduct;
        }
        public Task<List<Product>> ListAll(string search, string orderBy, string direction)
        {
            var products = Task.FromResult
               (_dapperService.GetAll<Product>
               ($"SELECT * \r\nFROM PRODUCT p LEFT JOIN Brand b\r\nON p.BrandId = b.BrandId LEFT JOIN Category c ON p.CategoryId = c.CategoryId WHERE {search} ORDER BY {orderBy} {direction};", null, commandType: CommandType.Text));
            return products;
        }
        public Task<int> Update(Product product)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ProductId", product.ProductId);
            dbPara.Add("ProductName", product.ProductName, DbType.String);
            dbPara.Add("Description", product.Description, DbType.String);
            dbPara.Add("Available", product.Available, DbType.Byte);
            dbPara.Add("UnitPrice", product.UnitPrice, DbType.Decimal);
            dbPara.Add("CategoryId", product.CategoryId, DbType.Int64);
            dbPara.Add("BrandId", product.BrandId, DbType.Int64);
            dbPara.Add("Threshold", product.Threshold, DbType.Int64);
            dbPara.Add("Picture", product.Picture, DbType.String);
            var updateProduct = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdateProduct]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updateProduct;
        }
        public Task<Product> GetByIdDetail(int id)
        {
            var product = Task.FromResult
               (_dapperService.Get<Product>
               ($"SELECT * FROM Product WHERE ProductId = {id}", null,
               commandType: CommandType.Text));
            return product;
        }
        public Task<Product> GetCategoryByName(string CategorytName)
        {
            var product = Task.FromResult
               (_dapperService.Get<Product>
               ($"select CategoryId from [Category] where CategoryName = '%{CategorytName}'%", null,
               commandType: CommandType.Text));
            return product;
        }
        
    }
       
}