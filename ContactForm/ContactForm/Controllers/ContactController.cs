using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactForm.Controllers
{
    public class ContactController : Controller
    {
        /// <summary>
        /// Returns contact form page.
        /// </summary>
        /// <returns></returns>
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}