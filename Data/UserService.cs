using OMS.Interfaces;
using OMS.Entities;
using Dapper;
using System.Data;


namespace OMS.Data
{
    public class UserService : IUserService
    {
        private readonly IDapperService _dapperService;
        public UserService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        public Task<int> Create(User user)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("UserName", user.Username, DbType.String);
            dbPara.Add("Email", user.Email, DbType.String);
            dbPara.Add("Password", user.Password, DbType.String);
            dbPara.Add("Suspended", user.Suspended, DbType.String);
            dbPara.Add("LastLoginDate", user.LastLoginDate, DbType.String);
            var UserId = Task.FromResult
               (_dapperService.Insert<int>("[dbo].[spAddUser]",
               dbPara, commandType: CommandType.StoredProcedure));
            return UserId;
        }
        
        public Task<int> Update(User user)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("UserId", user.UserId);
            dbPara.Add("Username", user.Username, DbType.String);
            dbPara.Add("Email", user.Email, DbType.String);
            dbPara.Add("Password", user.Password, DbType.String);
            dbPara.Add("Suspended", user.Suspended, DbType.Byte);
            dbPara.Add("LastLoginDate", user.LastLoginDate, DbType.DateTime);
            var updateUser = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdateUser]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updateUser;
        }

    }
}