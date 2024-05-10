using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;

namespace VetAppApi.Models
{
    public class RoleModel
    {
        private readonly IConfiguration _configuration;

        public RoleModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<RoleObj> GetRoles()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<RoleObj>("SP_GetRoles", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<RoleObj>();
    }
    }
}