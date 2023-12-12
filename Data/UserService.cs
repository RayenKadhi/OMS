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
            dbPara.Add("Username", user.Username, DbType.String);
            dbPara.Add("Email", user.Email, DbType.String);
            dbPara.Add("Password", user.Password, DbType.String);
            dbPara.Add("Suspended", user.Suspended, DbType.Byte);
            dbPara.Add("UserNameChanged", user.UserNameChanged, DbType.Int64);
            dbPara.Add("LastLoginDate", user.LastLoginDate, DbType.String);
            dbPara.Add("Avatar", user.Avatar, DbType.String);
            dbPara.Add("ConfirmationToken", user.ConfirmationToken, DbType.String);
            dbPara.Add("EmailSent", user.EmailSent, DbType.DateTime);
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
            dbPara.Add("UserNameChanged", user.UserNameChanged, DbType.Int64);
            dbPara.Add("LastLoginDate", user.LastLoginDate, DbType.DateTime);
            dbPara.Add("Avatar", user.Avatar, DbType.String);
            dbPara.Add("ConfirmationToken", user.ConfirmationToken, DbType.String);
            dbPara.Add("EmailSent", user.EmailSent, DbType.DateTime);
            var updateUser = Task.FromResult
               (_dapperService.Update<int>("[dbo].[spUpdateUser]",
               dbPara, commandType: CommandType.StoredProcedure));
            return updateUser;
        }
        public Task<List<User>> ListAll()
        {
            var users = Task.FromResult
               (_dapperService.GetAll<User>
               ($"SELECT * FROM [User]", null, commandType: CommandType.Text));
            return users;
        }
        public Task<User> GetById(int id)
        {
            var user = Task.FromResult
               (_dapperService.Get<User>
               ($"select * from [User] where UserId = {id}", null,
               commandType: CommandType.Text));
            return user;
        }
        public Task<int> Count()
        {
            var totUsers = Task.FromResult(_dapperService.Get<int>
               ($"select COUNT(*) from [User]", null,

               commandType: CommandType.Text));
            return totUsers;
        }

    }
}