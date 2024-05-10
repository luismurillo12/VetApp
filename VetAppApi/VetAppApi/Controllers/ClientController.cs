using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private ClientModel _clientModel;

        public ClientController(ClientModel clientModel)
        {
            _clientModel = clientModel;
        }

        [HttpGet]
        [Route("GetClients")]
        public ActionResult<IEnumerable<ClientObj>> GetClients()
        {
            return _clientModel.GetClients().ToList();
        }

        [HttpPost]
        [Route("CreateClient")]
        public ActionResult<int> CreateClient(ClientObj clientObj)
        {
            return _clientModel.CreateClient(clientObj);
        }

        [HttpPut]
        [Route("UpdateClient")]
        public ActionResult<int> UpdateClient(ClientObj clientObj)
        {
            return _clientModel.UpdateClient(clientObj);
        }


        [HttpDelete]
        [Route("DeleteClient")]
        public ActionResult<int> DeleteClient(int idClient)
        {
            return _clientModel.DeleteClient(idClient);
        }
    }
}