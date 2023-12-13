using Dapper;
using OMS.Entities;
using OMS.Interfaces;
using System.Data;

namespace OMS.Data
{
    public class BrandService : IBrandService
    {
        private readonly IDapperService _dapperService;
        public BrandService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        public Task<int> Create(Brand brand)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("BrandName", brand.BrandName, DbType.String);
            var BrandId = Task.FromResult
               (_dapperService.Insert<int>("[dbo].[spAddBrand]",
               dbPara, commandType: CommandType.StoredProcedure));
            return BrandId;
        }

        public Task<int> Delete(int id)
        {
            var deleteBrand = Task.FromResult
               (_dapperService.Execute
               ($"Delete [Brand] where BrandId = {id}", null,
               commandType: CommandType.Text));
            return deleteBrand;
        }


        public Task<int> Update(Brand brand)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("BrandId", brand.BrandId);
            dbPara.Add("BrandName", brand.BrandName, DbType.String);
            var updateBrand = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdateBrand]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updateBrand;
        }
        public Task<List<Brand>> ListAll(
         string orderBy, string direction = "DESC", string search = "")
        {
            var brands = Task.FromResult
               (_dapperService.GetAll<Brand>
               ($"SELECT * FROM [Brand] WHERE BrandName like'%{search}%' ORDER BY {orderBy} {direction}; ", null, commandType: CommandType.Text));
            return brands;
        }
        public Task<int> Count()
        {
            var totBrand = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Brand]", null,

               commandType: CommandType.Text));
            return totBrand;
        }
    }
}
