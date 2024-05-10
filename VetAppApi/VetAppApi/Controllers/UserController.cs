using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserModel _userModel;

        public UserController(UserModel userModel) { 
            _userModel= userModel;  
        }

        [HttpPost]
        [Route("CreateUser")]
        public ActionResult<int> CreateUser(UserObj userObj)
        {
            return _userModel.CreateUser(userObj);
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<IEnumerable<UserObj>> GetUsers()
        {
            return _userModel.GetUsers().ToList();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<int> UpdateUser(UserObj userObj)
        {
            return _userModel.UpdateUser(userObj);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult<int> DeleteUser(int idUser)
        {
            return _userModel.DeleteUser(idUser);
        }

		[HttpGet]
		[Route("ValidateUserMailExist")]
		public ActionResult<UserObj> ValidateUserMailExist(string email)
		{
			return _userModel.ValidateUserMailExist(email);
		}

		[HttpPut]
		[Route("UpdateUserPassword")]
		public ActionResult<int> UpdateUserPassword(UserObj userObj)
		{
			return _userModel.UpdateUserPassword(userObj);
		}

        [HttpGet]
        [Route("GetDoctors")]
        public ActionResult<IEnumerable<UserObj>> GetDoctors()
        {
            return _userModel.GetDoctors().ToList();
        }
    }
}
