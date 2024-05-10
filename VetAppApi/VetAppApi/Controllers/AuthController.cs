using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using VetAppApi.Entities;
using VetAppApi.Models;
using VetAppApi.Services;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthModel? _authModel;
        private readonly EmailSend _emailSend;

        public AuthController(AuthModel authModel, EmailSend emailSend)
        {
            _authModel = authModel;
            _emailSend = emailSend;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<UserObj> Login(UserObj userObj)
        {
            try
            {
                var data = _authModel?.Login(userObj);
                return data != null ? Ok(data) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al iniciar sesión. " + ex);
            }
        }

		[HttpPost]
		[Route("RequestNewPasswordEmailSend")]
		public ActionResult<string> RequestNewPasswordEmailSend(UserObj userObj)
		{
			try
			{
				_emailSend.RequestNewPasswordEmailSend(userObj.UserMail);

                return "Solicitud enviada correctamente.";
			}
			catch (Exception ex)
			{
				return BadRequest("Se produjo un error al enviar la solicitud. " + ex);
			}
		}
	}
}