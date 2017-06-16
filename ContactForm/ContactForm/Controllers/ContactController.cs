using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ContactForm.Controllers
{
    public class ContactController : Controller
    {
        static string smtpServer = null;
        static int? smtpPort;
        static bool? enableSsl = null;
        static string smtpUsername = null;
        static string smtpPassword = null;      

        /// <summary>
        /// Returns contact form page.
        /// </summary>
        /// <returns></returns>
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sends email containing data that user provided from /Contact/Index.
        /// </summary>
        /// <param name="firstName">First name of the user.</param>
        /// <param name="email">Email of the user.</param>
        /// <param name="subject">Subject of method provided by user.</param>
        /// <param name="message">Message body provided by user.</param>
        /// <returns>Status code 200 (OK) if valid data and mail is sent successfully.</returns>
        /// <returns>Status code 500 (internal error) for any error.</returns>
        // POST: Contact/SendForm
        [HttpPost]
        public ActionResult SendForm(string firstName, string email, string subject, 
            string message)
        {
            HttpStatusCodeResult result;
            try
            {
                if (string.IsNullOrWhiteSpace(smtpServer))
                    smtpServer = ConfigurationManager.AppSettings.Get("ContactSMTPServer");

                if (smtpPort == null)
                    smtpPort = int.Parse(ConfigurationManager.AppSettings.Get("ContactSMTPPort"));

                if (enableSsl == null)
                    enableSsl = bool.Parse(ConfigurationManager.AppSettings.Get("ContactSMTPEnableSSL"));        

                if (string.IsNullOrWhiteSpace(smtpUsername))
                    smtpUsername = ConfigurationManager.AppSettings.Get("ContactSMTPUser");

                if (string.IsNullOrWhiteSpace(smtpPassword))
                    smtpPassword = ConfigurationManager.AppSettings.Get("ContactSMTPPassword");

                SmtpClient smtpClient = new SmtpClient(smtpServer, (int)smtpPort);
                smtpClient.EnableSsl = (bool)enableSsl;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.Send(email, smtpUsername, string.Format("{0} - {1}", subject, firstName), message);
                smtpClient.Dispose();

                result = new HttpStatusCodeResult(HttpStatusCode.OK,
                    "Email successfully sent!");
            }
            catch (SmtpException)
            {
                result = new HttpStatusCodeResult(HttpStatusCode.InternalServerError,
                    "An error occurred while sending the email. Please try again later.");
            }
            catch (Exception)
            {
                result = new HttpStatusCodeResult(HttpStatusCode.InternalServerError,
                    "An error occurred.Please try again later.");
            }

            return result;                       
        }
    }
}