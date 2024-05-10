using Dapper;
using VetAppApi.Entities;
using System.Data;
using System.Data.SqlClient;

namespace VetAppApi.Models
{
    public class ProductModel
    {
        private readonly IConfiguration _configuration;

        public ProductModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<ProductObj> GetProducts()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<ProductObj>("SP_GetProducts", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<ProductObj>();
        }





        public int CreateProduct(ProductObj productObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_RegisterProduct",
                        new
                        {
                            productObj.idSupplier,
                            productObj.product,
                            productObj.productBuyCost,
                            productObj.productSellCost
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


        public int UpdateProduct(ProductObj productObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdateProduct",
                        new
                        {
                            productObj.idProduct,
							productObj.idSupplier,
							productObj.product,
							productObj.productBuyCost,
							productObj.productSellCost
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

        public int DeleteProduct(int idProduct)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteProduct",
                        new
                        {
                            idProduct
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

                public List<ProductObj> GetProductsBySupplier(int idSupplier)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                connection.Open();
                return connection.Query<ProductObj>("SP_GetProductsBySupplier", new { idSupplier = idSupplier}, commandType: CommandType.StoredProcedure).ToList();
            }
        }




    }
}