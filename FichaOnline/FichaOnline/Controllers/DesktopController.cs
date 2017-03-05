using FichaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaOnline.Controllers
{
    public class DesktopController : Controller
    {
        public ActionResult Inicio()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            return View((Usuario)Session["usuario"]);
        }

        public ActionResult Sair()
        {
            Session.RemoveAll();
            return RedirectToAction("Entrar", "Entrada");
        }
    }
}
