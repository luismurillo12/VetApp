using Dapper;
using VetAppApi.Entities;
using System.Data;
using System.Data.SqlClient;


namespace VetAppApi.Models
{
    public class SupplierModel
    {
        private readonly IConfiguration _configuration;

        public SupplierModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<SupplierObj> GetSuppliers()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<SupplierObj>("SP_GetSuppliers", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<SupplierObj>();
        }





        public int CreateSupplier(SupplierObj supplierObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_RegisterSupplier",
                        new
                        {
                            supplierObj.supplierName,
                            supplierObj.supplierPhoneNumber,
                            supplierObj.supplierIdCard
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


        public int UpdateSupplier(SupplierObj supplierObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdateSupplier",
                        new
                        {
                            supplierObj.idSupplier,
                            supplierObj.supplierName,
                            supplierObj.supplierPhoneNumber,
                            supplierObj.supplierIdCard
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

        public int DeleteSupplier(int idSupplier)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteSupplier",
                        new
                        {
                            idSupplier
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