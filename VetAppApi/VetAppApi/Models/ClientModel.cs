using Dapper;
using VetAppApi.Entities;
using System.Data;
using System.Data.SqlClient;

namespace VetAppApi.Models
{
    public class ClientModel
    {
        private readonly IConfiguration _configuration;

        public ClientModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<ClientObj> GetClients()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<ClientObj>("SP_GetClients", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<ClientObj>();
        }





        public int CreateClient(ClientObj clientObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_RegisterClient",
                        new
                        {
                            clientObj.clientName,
                            clientObj.clientFirstLastName,
                            clientObj.clientSecondLastName,
                            clientObj.clientIdCard,
                            clientObj.clientphoneNumber
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


        public int UpdateClient(ClientObj clientObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdateClient",
                        new
                        {
                            clientObj.idClient,
                            clientObj.clientName,
                            clientObj.clientFirstLastName,
                            clientObj.clientSecondLastName,
                            clientObj.clientIdCard,
                            clientObj.clientphoneNumber
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

        public int DeleteClient(int idClient)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteClient",
                        new
                        {
                            idClient
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