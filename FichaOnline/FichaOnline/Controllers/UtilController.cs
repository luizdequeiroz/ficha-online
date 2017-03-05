using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaOnline.Controllers
{
    public class UtilController : Controller
    {
        [NonAction]
        public static string RenderAlert(string titulo, string mensagem, string tipo)
        {
            return "showAlert('" + titulo + "','" + mensagem + "','" + tipo + "');";
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}
