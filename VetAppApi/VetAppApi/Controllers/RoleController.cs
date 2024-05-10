using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleModel _roleModel;

        public RoleController(RoleModel roleModel)
        {
            _roleModel = roleModel;
        }

        [HttpGet]
        [Route("GetRoles")]
        public ActionResult<IEnumerable<RoleObj>> GetRoles()
        {
            return _roleModel.GetRoles().ToList();
        }
    }
}
