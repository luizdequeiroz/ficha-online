using FichaOnline.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FichaOnline.Models.Facade;
using FichaOnline.Models;

namespace FichaOnline.Controllers
{
    public class PRIAController : Controller
    {
        public ActionResult Listar(int fichaId, string tipo)
        {
            ViewBag.Tipo = tipo;
            return View(new PRIADao().ListarPorFichaIdETipo(fichaId, tipo));
        }

        public ActionResult Administrar(int fichaId, string tipo)
        {
            ViewBag.Tipo = tipo;
            ViewBag.IdTipo = new object[] { fichaId, tipo };
            if (fichaId == 0) return View(new PRIADao().ListarPorTipo(tipo));
            else return View(new PRIADao().ListarPorFichaIdETipo(fichaId, tipo));
        }

        public ActionResult Editar(int id)
        {
            return View(new PRIAFacade(new PRIADao().SelecionarPorId(id)));
        }

        [HttpPost]
        public ActionResult Editar(PRIAFacade pria, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pria.PropriedadeRiquezaItemArma.Id = id;
                    new PRIADao().Atualizar(pria.PropriedadeRiquezaItemArma);
                    Session["alert"] = UtilController.RenderAlert("Sucesso!", "A " + ((pria.Tipo == "pr/ri") ? "Propriedade/Riqueza " + pria.Descricao : "Item/Arma " + pria.Nome) + " foi editada com sucesso!", "success");
                    return View(pria);
                }
                catch (Exception ex)
                {
                    Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar editar. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                    return View();
                }
            }
            Session["alert"] = UtilController.RenderAlert("Ops!", "Preencha os campos corretamente e não deixe os obrigatórios em branco.", "warning");
            return View();
        }

        public ActionResult Criar(int id, string tipo)
        {
            return View(new PRIAFacade(new PropriedadeRiquezaItemArma { FichaId = id, Tipo = tipo }));
        }

        [HttpPost]
        public ActionResult Criar(PRIAFacade pria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new PRIADao().Inserir(pria.PropriedadeRiquezaItemArma);
                    Session["alert"] = UtilController.RenderAlert("Sucesso!", "A  " + pria.Nome + " foi criada com sucesso!", "success");
                    return View(new PRIAFacade(new PropriedadeRiquezaItemArma { FichaId = pria.FichaId, Tipo = pria.Tipo }));
                }
                catch (Exception ex)
                {
                    Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar criar. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                    return View(new PRIAFacade(new PropriedadeRiquezaItemArma { FichaId = pria.FichaId, Tipo = pria.Tipo }));
                }
            }
            Session["alert"] = UtilController.RenderAlert("Ops!", "Preencha os campos corretamente e não deixe os obrigatórios em branco.", "warning");
            return View(new PRIAFacade(new PropriedadeRiquezaItemArma { FichaId = pria.FichaId, Tipo = pria.Tipo }));
        }

        public JsonResult AutocompletePropriedadeRiqueza(string term)
        {
            return Json(new PRIADao().SelecionarDescricoesPropriedadeRiqueza(term, "pr/ri"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteItemArma(string term)
        {
            return Json(new PRIADao().SelecionarSubtipo(term, "it/ar"), JsonRequestBehavior.AllowGet);
        }
    }
}
