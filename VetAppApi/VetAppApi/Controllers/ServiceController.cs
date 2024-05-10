using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private ServiceModel _serviceModel;

        public ServiceController(ServiceModel serviceModel)
        {
            _serviceModel = serviceModel;
        }

        [HttpGet]
        [Route("GetServices")]
        public ActionResult<IEnumerable<ServiceObj>> GetServices()
        {
            return _serviceModel.GetServices().ToList();
        }

        [HttpPost]
        [Route("CreateService")]
        public ActionResult<int> CreateService(ServiceObj serviceObj)
        {
            return _serviceModel.CreateService(serviceObj);
        }

        [HttpPut]
        [Route("UpdateService")]
        public ActionResult<int> UpdateService(ServiceObj serviceObj)
        {
            return _serviceModel.UpdateService(serviceObj);
        }


        [HttpDelete]
        [Route("DeleteService")]
        public ActionResult<int> DeleteService(int idService)
        {
            return _serviceModel.DeleteService(idService);
        }
    }
}