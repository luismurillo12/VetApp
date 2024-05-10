using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;
using VetAppApi.Services;

namespace VetAppApi.Models
{
    public class UserModel
    {
        private readonly IConfiguration _configuration;

        public UserModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CreateUser(UserObj userObj)
        {
            try
            {
				string userPassword = PasswordHash.EncryptPassword(userObj.UserPassword);

				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_CreateUsers",
                        new { userObj.IdRol
                        , userObj.UserName
                        , userObj.UserFirstLastName
                        , userObj.UserSecondLastName
                        , userObj.UserIdCard
                        , userObj.UserMail
                        , userObj.UserNickName
                        , userPassword
						, userObj.UserPhoneNumber
                        , userObj.UserPicture}
                        ,
                        commandType: CommandType.StoredProcedure);

                    return datos;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        public IEnumerable<UserObj> GetUsers()
        {
            
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<UserObj>("SP_GetUsers", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<UserObj>();
        }

        public int UpdateUser(UserObj userObj)
        {
            try
            {
                string userPassword = String.Empty;

                if (!String.IsNullOrEmpty(userObj.UserPassword))
                {
                    userPassword = PasswordHash.EncryptPassword(userObj.UserPassword);
                }
                

                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdateUser",
                        new
                        {
                            userObj.IdUser
                        ,
                            userObj.IdRol
                        ,
                            userObj.UserMail
                        ,
                            userObj.UserNickName
                        ,
                            userPassword
                        ,
                            userObj.UserPhoneNumber
                        ,
                            userObj.UserPicture
                        },
                        commandType: CommandType.StoredProcedure);

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        public int DeleteUser(int idUser)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteUser",
                        new
                        {
                            idUser
                        },
                        commandType: CommandType.StoredProcedure);

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

		public UserObj? ValidateUserMailExist(string userMail)
		{

			try
			{
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<UserObj>("SP_ValidateUserMailExist", new
                    {
                        userMail
                    },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                    
                    if(datos != null)
                    {
                        return datos;
                    }

					return new UserObj();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new UserObj();
		}

		public int UpdateUserPassword(UserObj userObj)
		{
			try
			{
				string userPassword = PasswordHash.EncryptPassword(userObj.UserPassword);

				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Execute("SP_UpdateUserPassword",
						new
						{
							userObj.UserMail
						,
							userPassword
						},
						commandType: CommandType.StoredProcedure);

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return 0;
		}

        public IEnumerable<UserObj> GetDoctors()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<UserObj>("SP_GetDoctors", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<UserObj>();
        }
    }
}
