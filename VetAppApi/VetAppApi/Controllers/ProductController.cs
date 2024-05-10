using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ProductModel _productModel;

        public ProductController(ProductModel productModel)
        {
            _productModel = productModel;
        }

        [HttpGet]
        [Route("GetProducts")]
        public ActionResult<IEnumerable<ProductObj>> GetProducts()
        {
            return _productModel.GetProducts().ToList();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public ActionResult<int> CreateProduct(ProductObj productObj)
        {
            return _productModel.CreateProduct(productObj);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult<int> UpdateProduct(ProductObj productObj)
        {
            return _productModel.UpdateProduct(productObj);
        }


        [HttpDelete]
        [Route("DeleteProduct")]
        public ActionResult<int> DeleteProduct(int idProduct)
        {
            return _productModel.DeleteProduct(idProduct);
        }

		[HttpGet("GetProductsBySupplier/{idSupplier}")]
		public ActionResult<List<ProductObj>> GetProductsBySupplier(int idSupplier)
		{
			try
			{
				var products = _productModel.GetProductsBySupplier(idSupplier);
				return products != null ? products : NotFound();
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while fetching reviews." + ex.Message);
			}
		}
	}
}