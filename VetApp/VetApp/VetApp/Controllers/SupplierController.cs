using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class SupplierController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly SupplierModel _supplier;
		private readonly ProductModel _product;
		public List<SupplierObj> _suppliersObject;
		ProductModel _productModel ;
		public SupplierController(IConfiguration configuration)
        {
            _configuration = configuration;
            _supplier = new SupplierModel(configuration);
            _productModel = new ProductModel(configuration);
			_product = new ProductModel(configuration);
			_suppliersObject = _supplier.GetSuppliers();

			

		}


        public IActionResult Supplier()
        {
            ViewBag.Suppliers = _suppliersObject;
            return View();
        }

        public IActionResult AgregarEmpleado()
        {
            return View();
        }

        public IActionResult Employee()
        {

            return View();
        }

        public IActionResult EditarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateSupplier(SupplierObj supplierObj)
        {

            var createSupplier = _supplier.CreateSupplier(supplierObj);
            return Json(createSupplier);
        }

        [HttpGet]
        public JsonResult GetSupplier(int idSupplier)
        {
            var user = _suppliersObject.Where(data => data.idSupplier == idSupplier).FirstOrDefault();
            return Json(user);
        }

        [HttpPut]
        public JsonResult UpdateSupplier(SupplierObj supplierObj)
        {
            var createSupplier = _supplier.UpdateSupplier(supplierObj);
            return Json(createSupplier);
        }

        [HttpDelete]
        public JsonResult DeleteSupplier(int idSupplier)
        {
            var supplier = _supplier.DeleteSupplier(idSupplier);
            return Json(supplier);
        }

		[HttpGet("Supplier/Product/{idSupplier}")]
		public IActionResult Product(int idSupplier)
		{
            var products = _productModel.GetProductsBySupplier(idSupplier);
			ViewBag.Products = products;
            ViewBag.IdSupplier = idSupplier;
			return View();
		}


		[HttpPost]
		public JsonResult CreateProduct(ProductObj productObj)
		{

			var createProduct = _product.CreateProduct(productObj);
			return Json(createProduct);
		}

		[HttpGet]
		public JsonResult ValidateSupplierIdCardExist(string supplierIdCard)
		{
			var user = _suppliersObject.Where(data => data.supplierIdCard == supplierIdCard).FirstOrDefault();
			return Json(user);
		}
	}
}