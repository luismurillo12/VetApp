using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using VetAppApi.Entities;
using VetAppApi.Services;

namespace VetAppApi.Models
{
    public class AuthModel
    {

        private readonly IConfiguration _configuration;

        public AuthModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserObj? Login(UserObj userObj)
        {
            string userPassword = PasswordHash.EncryptPassword(userObj.UserPassword); 

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<UserObj>("SP_LogIn",
                    new
                    {
                        userObj.UserNickName,
                        userPassword
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
