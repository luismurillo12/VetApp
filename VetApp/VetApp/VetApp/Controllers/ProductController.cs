using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class ProductController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly ProductModel _productModel;
        public List<ProductObj> _productsList;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            _productModel = new ProductModel(configuration);
            _productsList = _productModel.GetProducts();

        }

		public IActionResult Product(int idSupplier = 0)
		{
			if (idSupplier == 0)
			{
				//ViewBag.Pets = _petsList;

				return RedirectToAction("Supplier", "Supplier");
			}
			else
			{
				ViewBag.Products = _productModel.GetProductsBySupplier(idSupplier);
				ViewBag.IdSupplier= idSupplier;

			}

			return View();
		}


		[HttpPost]
        public JsonResult CreateProduct(ProductObj productObj)
        {

            var createProduct = _productModel.CreateProduct(productObj);
            return Json(createProduct);
        }

        [HttpGet]
        public JsonResult GetProduct(int idProduct)
        {
            var getproduct = _productsList.Where(data => data.idProduct == idProduct).FirstOrDefault();
            return Json(getproduct);
        }

        [HttpPut]
        public JsonResult UpdateProduct(ProductObj productObj)
        {
            var updateProduct = _productModel.UpdateProduct(productObj);
            return Json(updateProduct);
        }

        [HttpDelete]
        public JsonResult DeleteProduct(int idProduct)
        {
            var deleteproduct = _productModel.DeleteProduct(idProduct);
            return Json(deleteproduct);
        }

    }
}