using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;
using System.Globalization;
using VetAppApi.Services;

namespace VetAppApi.Models
{
    public class PaymentModel
    {
        private readonly IConfiguration _configuration;

        public PaymentModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<PaymentTypeObj> GetPaymentType()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<PaymentTypeObj>("SP_GetPaymentTypes", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<PaymentTypeObj>();
        }

        public IEnumerable<InvoicesListObj> GetInvoices(string startDate, string endDate)
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<InvoicesListObj>("SP_GetInvoices", new
                    {
                        startDate
                        ,
                        endDate
                    },
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<InvoicesListObj>();
        }

        public int CreateInvoices(InvoicesObj invoices)
        {

            try
            {
                if (invoices.invoiceType == 2)
                {
                    invoices.Credit.IdCredit = InsertCredits(invoices.Credit);
                }

                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<int>("SP_InsertInvoice",
                        new
                        {
                            invoices.numReference,
                            invoices.dateInvoices,
                            invoices.totalCancel,
                            invoices.totalCanceled,
                            invoices.idPaymentType,
                            invoices.idClient,
                            invoices.Credit.IdCredit
                        },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (datos > 0)
                    {
                        invoices.idInvoices = datos;
                    }

                    if(invoices.DetailInvoices == null)
                    {
                        return datos;
                    }
                }

                return CreateDetail(invoices);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }


        public IEnumerable<DetailListObj> GetDetailByIdInvoices(int idInvoice)
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<DetailListObj>("SP_GetDetailByIdInvoices", new { idInvoice },
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<DetailListObj>();
        }

        public int CreateDetail(InvoicesObj detail)
        {
            try
            {
                int status = 0;
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    foreach (var details in detail.DetailInvoices.ToList())
                    {
                        var datos = connection.Execute("SP_InsertDetail",
                        new
                        {
                            details.nameDetail,
                            details.descriptionDetail,
                            details.amountDetail,
                            details.costDetail,
                            detail.idInvoices
                        },
                        commandType: CommandType.StoredProcedure);

                        status = datos;
                    }

                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        public int InsertCredits(CreditObj credit)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<int>("SP_InsertCredits",
                        new
                        {
                            credit.IdCredit
                             ,
                            credit.DateCredit
                             ,
                            credit.TotalBalance
                             ,
                            credit.TotalCredit
                        },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return datos;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        public IEnumerable<CreditListObj> GetCredits(int idClient)
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<CreditListObj>("SP_GetCredits", new { idClient },
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<CreditListObj>();
        }

        public IEnumerable<CreditListObj> GetCreditsReport(string startDate, string @endDate)
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<CreditListObj>("SP_GetCreditsReport", new { startDate , @endDate },
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<CreditListObj>();
        }

        public IEnumerable<CreditListObj> GetDepositsCreditsByIdClient(int idClient)
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<CreditListObj>("SP_GetDepositsCreditsByIdClient", new { idClient },
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<CreditListObj>();
        }



    }
}
