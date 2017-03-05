using FichaOnline.Models;
using FichaOnline.Models.DAO;
using FichaOnline.Models.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaOnline.Controllers
{
    public class FichaController : Controller
    {
        public ActionResult Minhas()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            return View(new FichaDao().ListarPorUsuarioId(((Usuario)Session["usuario"]).Id));
        }

        public ActionResult Outras()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            return View(new FichaDao().ListarPorMestreId(((Usuario)Session["usuario"]).Id));
        }

        public ActionResult Nova()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            return View();
        }

        [HttpPost]
        public ActionResult Nova(FichaFacade ficha, int Nivel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var totalPts = (Nivel - 2.5) * 9;
                    var totalPtsPec = Math.Floor(Nivel - 2.5) * 10;
                    var pts = totalPts - (ficha.Adre + ficha.Ataq + ficha.Defe + ficha.Dest + ficha.Forc + ficha.Inte + ficha.Resi + ficha.Sabe + ficha.Velo);
                    ficha.Pontos = Convert.ToInt32(Math.Floor(pts));
                    ficha.PtsPeculiaridades = Convert.ToInt32(totalPtsPec);
                    var usuarioId = ((Usuario)Session["usuario"]).Id;
                    ficha.Ficha.UsuarioId = usuarioId;
                    if (ficha.Mestre != null) ficha.Ficha.MestreId = new UsuarioDao().SelecionarPorEmail(ficha.Mestre.Split(',')[1].Trim()).Id;
                    new FichaDao().Inserir(ficha.Ficha);
                    Session["alert"] = UtilController.RenderAlert("Sucesso!", "A Ficha " + ficha.Nome + " foi criada com sucesso!", "success");
                    return RedirectToAction("Minhas");
                }
                catch (Exception ex)
                {
                    Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar cadastrar. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                    if (Session["usuario"] == null)
                        return RedirectToAction("Entrar", "Entrada");
                    return View();
                }
            }
            Session["alert"] = UtilController.RenderAlert("Ops!", "Preencha os campos corretamente e não deixe os obrigatórios em branco.", "warning");
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            return View();
        }

        public ActionResult Ver(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            return View(new FichaDao().SelecionarPorId(id));
        }

        public ActionResult Editar(int id)
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            Session["autorizado"] = false;
            var ficha = new FichaDao().SelecionarPorId(id);
            var mestre = new UsuarioDao().SelecionarPorId(ficha.MestreId);
            var jogador = new UsuarioDao().SelecionarPorId(ficha.UsuarioId);
            var fichafac = new FichaFacade(ficha);
            if (mestre != null) fichafac.Mestre = mestre.Nome + ", " + mestre.Email;
            fichafac.Jogador = jogador.Nome + ", " + jogador.Email;
            if (ficha.MestreId == ((Usuario)Session["usuario"]).Id) Session["autorizado"] = true;
            return View(fichafac);
        }

        [HttpPost]
        public ActionResult Editar(FichaFacade ficha, int Id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jogadorId = new UsuarioDao().SelecionarPorEmail(ficha.Jogador.Split(',')[1].Trim()).Id;
                    if (ficha.Mestre != null) ficha.Ficha.MestreId = new UsuarioDao().SelecionarPorEmail(ficha.Mestre.Split(',')[1].Trim()).Id;
                    ficha.Ficha.Id = Id;
                    ficha.Ficha.UsuarioId = jogadorId;
                    new FichaDao().Atualizar(ficha.Ficha);
                    Session["alert"] = UtilController.RenderAlert("Sucesso!", "A Ficha " + ficha.Nome + " foi editada com sucesso!", "success");
                    return View(ficha);
                }
                catch (Exception ex)
                {
                    Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar editar. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                    if (Session["usuario"] == null)
                        return RedirectToAction("Entrar", "Entrada");
                    return View(ficha);
                }
            }
            Session["alert"] = UtilController.RenderAlert("Ops!", "Preencha os campos corretamente e não deixe os obrigatórios em branco.", "warning");
            if (Session["usuario"] == null)
                return RedirectToAction("Entrar", "Entrada");
            return View();
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                var ficha = new FichaDao().SelecionarPorId(id);
                if (ficha.Pontos > 0) ficha.Pontos = ficha.Pontos * (-1);
                else ficha.Pontos = -1000;
                new FichaDao().Atualizar(ficha);
                Session["alert"] = UtilController.RenderAlert("Sucesso!", "A Ficha " + ficha.Nome + " foi excluída com sucesso!", "success");
                return RedirectToAction("Minhas");
            }
            catch (Exception ex)
            {
                Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar excluir. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                if (Session["usuario"] == null)
                    return RedirectToAction("Entrar", "Entrada");
                return RedirectToAction("Minhas");
            }
        }

        public JsonResult AutocompleteClasse(string term)
        {
            return Json(new FichaDao().SelecionarNomesClasses(term), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteRaca(string term)
        {
            return Json(new FichaDao().SelecionarNomesRacas(term), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteJogador(string term)
        {
            return AutocompleteMestre(term);
        }

        public JsonResult AutocompleteMestre(string term)
        {
            return Json(new UsuarioDao().SelecionarMestres(term), JsonRequestBehavior.AllowGet);
        }
    }
}
