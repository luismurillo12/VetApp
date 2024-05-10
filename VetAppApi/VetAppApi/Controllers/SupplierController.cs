using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private SupplierModel _supplierModel;

        public SupplierController(SupplierModel supplierModel)
        {
            _supplierModel = supplierModel;
        }

        [HttpGet]
        [Route("GetSuppliers")]
        public ActionResult<IEnumerable<SupplierObj>> GetSuppliers()
        {
            return _supplierModel.GetSuppliers().ToList();
        }

        [HttpPost]
        [Route("CreateSupplier")]
        public ActionResult<int> CreateSupplier(SupplierObj supplierObj)
        {
            return _supplierModel.CreateSupplier(supplierObj);
        }

        [HttpPut]
        [Route("UpdateSupplier")]
        public ActionResult<int> UpdateSupplier(SupplierObj supplierObj)
        {
            return _supplierModel.UpdateSupplier(supplierObj);
        }


        [HttpDelete]
        [Route("DeleteSupplier")]
        public ActionResult<int> DeleteSupplier(int idSupplier)
        {
            return _supplierModel.DeleteSupplier(idSupplier);
        }
    }
}