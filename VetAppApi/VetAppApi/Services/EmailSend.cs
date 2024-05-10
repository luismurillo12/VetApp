using System.Net.Mail;

namespace VetAppApi.Services
{
	public class EmailSend
	{
		private readonly IConfiguration _configuration;
		private IHostEnvironment _hostingEnvironment;

		public EmailSend(IConfiguration configuration, IHostEnvironment hostingEnvironment)
		{
			_configuration = configuration;
			_hostingEnvironment = hostingEnvironment;
		}

		public void RequestNewPasswordEmailSend(string email)
		{
			string correoSMTP = _configuration.GetSection("Claves:correoSMTP").Value;
			string claveSMTP = _configuration.GetSection("Claves:claveSMTP").Value;

			MailMessage msg = new MailMessage();
			msg.To.Add(new MailAddress(correoSMTP));
			msg.From = new MailAddress(correoSMTP);
			msg.Subject = "Solicitud de cambio de contraseña";
			msg.Body = SetEmailTemplate(email);
			msg.IsBodyHtml = true;

			SmtpClient client = new SmtpClient();
			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential(correoSMTP, claveSMTP);
			client.Port = 587;
			client.Host = "smtp.office365.com";
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.EnableSsl = true;
			client.Send(msg);
		}

		public string SetEmailTemplate(string email) {
			string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "EmailTemplate\\PasswordRequest.html");
			string htmlTemplate = System.IO.File.ReadAllText(filePath);
            string siteVetAppUrl = _configuration.GetSection("Claves:siteVetAppUrl").Value;

            htmlTemplate = htmlTemplate.Replace("@@UserEmail", email);
			htmlTemplate = htmlTemplate.Replace("@@Link", siteVetAppUrl + "Administration/UpdateUserPassword?email=" + email);

			return htmlTemplate;
		}
	}
}
