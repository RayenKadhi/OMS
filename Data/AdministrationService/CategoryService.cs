using Dapper;
using OMS.Entities;
using OMS.Interfaces;
using System.Data;

namespace OMS.Data
{

        public class CategoryService : ICategoryService
        {
            private readonly IDapperService _dapperService;
            public CategoryService(IDapperService dapperService)
            {
                this._dapperService = dapperService;
            }
            public Task<int> Create(Category category)
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("CategoryName", category.CategoryName, DbType.String);
                var CategoryId = Task.FromResult
                   (_dapperService.Insert<int>("[dbo].[spAddCategory]",
                   dbPara, commandType: CommandType.StoredProcedure));
                return CategoryId;
            }
          
            public Task<int> Delete(int id)
            {
                var deleteCategory = Task.FromResult
                   (_dapperService.Execute
                   ($"Delete [Category] where CategoryId = {id}", null,
                   commandType: CommandType.Text));
                return deleteCategory;
            }
         
         
            public Task<int> Update(Category category)
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("CategoryId", category.CategoryId);
                dbPara.Add("CategoryName", category.CategoryName, DbType.String);  
                var updateCategory = Task.FromResult
                   (_dapperService.Update<int>("[dbo].[spUpdateCategory]",
                   dbPara, commandType: CommandType.StoredProcedure));
                return updateCategory;
            }
        public Task<List<Category>> ListAll(
         string orderBy, string direction = "DESC", string search = "")
        {
            var categories = Task.FromResult
               (_dapperService.GetAll<Category>
               ($"SELECT * FROM [Category] WHERE CategoryName like'%{search}%' ORDER BY {orderBy} {direction}; ", null, commandType: CommandType.Text));
            return categories;
        }
        public Task<int> Count()
        {
            var totcategory = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [Category]", null,
   
               commandType: CommandType.Text));
            return totcategory;
        }
    }
}

