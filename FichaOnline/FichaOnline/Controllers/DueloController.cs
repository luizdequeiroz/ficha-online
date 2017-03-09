using FichaOnline.Models;
using FichaOnline.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaOnline.Controllers
{
    public class DueloController : Controller
    {
        public ActionResult Listar(int id)
        {
            try
            {
                List<Ficha> fichas = new List<Ficha>();
                fichas.AddRange(new FichaDao().ListarPorUsuarioId(id));
                fichas.AddRange(new FichaDao().ListarPorMestreId(id));
                return View(fichas);
            }
            catch (Exception ex)
            {
                Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar listar fichas. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                if (Session["usuario"] == null)
                    return RedirectToAction("Entrar", "Entrada");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Duelando(int[] fichasId)
        {
            if (fichasId.Count() >= 2)
            {
                List<Ficha> fichas = new List<Ficha>();
                foreach (int id in fichasId)
                    fichas.Add(new FichaDao().SelecionarPorId(id));
                return View(fichas);
            }
            else
            {
                Session["alert"] = UtilController.RenderAlert("Ops!", "Selecione pelo menos 2 fichas!", "warning");
                if (Session["usuario"] == null)
                    return RedirectToAction("Entrar", "Entrada");
                return View();
            }
        }
    }
}
