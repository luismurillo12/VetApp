using Dapper;
using VetAppApi.Entities;
using System.Data;
using System.Data.SqlClient;

namespace VetAppApi.Models
{
    public class ServiceModel
    {
        private readonly IConfiguration _configuration;

        public ServiceModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<ServiceObj> GetServices()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<ServiceObj>("SP_GetServices", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<ServiceObj>();
        }





        public int CreateService(ServiceObj serviceObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_RegisterService",
                        new
                        {
                            serviceObj.serviceName,
                            serviceObj.serviceCost
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


        public int UpdateService(ServiceObj serviceObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdateService",
                        new
                        {
                            serviceObj.idService,
                            serviceObj.serviceName,
                            serviceObj.serviceCost
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

        public int DeleteService(int idService)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteService",
                        new
                        {
                            idService
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




    }
}