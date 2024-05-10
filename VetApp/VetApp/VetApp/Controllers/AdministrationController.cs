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
	public class AdministrationController : Controller
	{
		private readonly EmployeeModel _employee;
		private readonly RoleModel _role;
		public List<UserObj> _usersObject;
		private readonly IConfiguration _configuration;
        public AdministrationController(IConfiguration configuration)
        {
			_configuration = configuration;
			_role = new RoleModel(_configuration);
            _employee = new EmployeeModel(_configuration);
            _usersObject = _employee.GetUsers();

		}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarEmpleado()
        {
            return View();
        }

		[FilterSecurity]
		public IActionResult Employee()
        {
            ViewBag.Users = _usersObject;
            ViewBag.Roles = _role.GetRoles();
            return View();
        }

        public IActionResult EditarEmpleado()
        {
            return View();
        }

        [HttpPost]
		[FilterSecurity]
		public JsonResult CreateUser(UserObj userObj)
        {

			if (String.IsNullOrEmpty(userObj.UserPicture))
			{
				userObj.UserPicture = "";

			}
			else
			{
				userObj.UserPicture = SaveImage.SaveImageBase64(userObj.UserPicture, userObj.UserIdCard.ToString());
			}

			var createUser = _employee.CreateUser(userObj);
            return Json(createUser);
        }

		[HttpGet]
		[FilterSecurity]
		public JsonResult GetUser(int idUser)
		{
			var user = _usersObject.Where(data => data.IdUser == idUser).FirstOrDefault();
			return Json(user);
		}

		[HttpPut]
		[FilterSecurity]
		public JsonResult UpdateUser(UserObj userObj)
		{
			if (String.IsNullOrEmpty(userObj.UserPassword))
			{
				userObj.UserPassword = "";

			}

			if (String.IsNullOrEmpty(userObj.UserPicture))
			{
                userObj.UserPicture = "";

			}
            else
            {
				userObj.UserPicture = SaveImage.SaveImageBase64(userObj.UserPicture, userObj.UserIdCard.ToString());
			}

			var createUser = _employee.UpdateUser(userObj);
			return Json(createUser);
		}

		[HttpDelete]
		[FilterSecurity]
		public JsonResult DeleteUser(int idUser)
		{
			var user = _employee.DeleteUser(idUser);
			return Json(user);
		}

		[HttpGet]
		public JsonResult ValidateUserMailExist(string userMail)
		{
			var user = _employee.ValidateUserMailExist(userMail);
			return Json(user);
		}

		[HttpGet]
		public IActionResult UpdateUserPassword(string? email = null)
		{
			ViewBag.Email = email;
			return View();
		}

		[HttpPut]
		public JsonResult UpdateUserPassword(UserObj userObj)
		{
			var updateUserPassword = _employee.UpdateUserPassword(userObj);
			return Json(updateUserPassword);
		}

		[HttpGet]
		[FilterSecurity]
		public JsonResult ValidateAliasExist(string userNickName)
		{
			var user = _usersObject.Where(data => data.UserNickName == userNickName).FirstOrDefault();
			return Json(user);
		}

		[HttpGet]
		[FilterSecurity]
		public JsonResult ValidateUserIdCardExist(string userIdCard)
		{
			var user = _usersObject.Where(data => data.UserIdCard == userIdCard).FirstOrDefault();
			return Json(user);
		}
	}
}
