using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private PaymentModel _paymentModel;
        public PaymentController(PaymentModel paymentModel)
        {
            _paymentModel = paymentModel;
        }

        [HttpGet]
        [Route("GetPaymentType")]
        public ActionResult<IEnumerable<PaymentTypeObj>> GetPaymentType()
        {
            return _paymentModel.GetPaymentType().ToList();
        }

        [HttpGet]
        [Route("GetInvoices")]
        public ActionResult<IEnumerable<InvoicesListObj>> GetInvoices(string startDate, string endDate)
        {
            return _paymentModel.GetInvoices(startDate, endDate).ToList();
        }

        [HttpPost]
        [Route("CreateInvoices")]
        public ActionResult<int> CreateInvoices(InvoicesObj invoices)
        {
            return _paymentModel.CreateInvoices(invoices);
        }

        [HttpGet]
        [Route("GetDetailByIdInvoices")]
        public ActionResult<IEnumerable<DetailListObj>> GetDetailByIdInvoices(int idInvoice)
        {
            return _paymentModel.GetDetailByIdInvoices(idInvoice).ToList();
        }

        [HttpGet]
        [Route("GetCredits")]
        public ActionResult<IEnumerable<CreditListObj>> GetCredits(int idClient)
        {
            return _paymentModel.GetCredits(idClient).ToList();
        }

        [HttpGet]
        [Route("GetDepositsCreditsByIdClient")]
        public ActionResult<IEnumerable<CreditListObj>> GetDepositsCreditsByIdClient(int idClient)
        {
            return _paymentModel.GetDepositsCreditsByIdClient(idClient).ToList();
        }
    }
}
