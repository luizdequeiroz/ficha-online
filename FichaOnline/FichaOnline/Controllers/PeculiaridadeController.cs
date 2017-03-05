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
    public class PeculiaridadeController : Controller
    {
        public ActionResult Listar(int fichaId, string tipo)
        {
            return View(new PeculiaridadeDao().ListarPorFichaIdETipo(fichaId, tipo));
        }

        public ActionResult Administrar(int fichaId, string tipo)
        {
            ViewBag.IdTipo = new object[] { fichaId, tipo };
            if (fichaId == 0) return View(new PeculiaridadeDao().ListarPorTipo(tipo));
            else return View(new PeculiaridadeDao().ListarPorFichaIdETipo(fichaId, tipo));
        }

        public ActionResult Editar(int id)
        {
            return View(new PeculFacade(new PeculiaridadeDao().SelecionarPorId(id)));
        }

        [HttpPost]
        public ActionResult Editar(PeculFacade pec, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pec.Peculiaridade.Id = id;
                    new PeculiaridadeDao().Atualizar(pec.Peculiaridade);
                    Session["alert"] = UtilController.RenderAlert("Sucesso!", "A Peculiaridade " + pec.Nome + " foi editada com sucesso!", "success");
                    return View(pec);
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
            return View(new PeculFacade(new Peculiaridade { FichaId = id, Tipo = tipo }));
        }

        [HttpPost]
        public ActionResult Criar(PeculFacade pec)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new PeculiaridadeDao().Inserir(pec.Peculiaridade);
                    Session["alert"] = UtilController.RenderAlert("Sucesso!", "A Peculiaridade " + pec.Nome + " foi criada com sucesso!", "success");
                    return View(new PeculFacade(new Peculiaridade { FichaId = pec.FichaId, Tipo = pec.Tipo }));
                }
                catch (Exception ex)
                {
                    Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar criar. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                    return View(new PeculFacade(new Peculiaridade { FichaId = pec.FichaId, Tipo = pec.Tipo }));
                }
            }
            Session["alert"] = UtilController.RenderAlert("Ops!", "Preencha os campos corretamente e não deixe os obrigatórios em branco.", "warning");
            return View(new PeculFacade(new Peculiaridade { FichaId = pec.FichaId, Tipo = pec.Tipo }));
        }

        public JsonResult AutocompleteCapacidade(string term)
        {
            return Json(new PeculiaridadeDao().SelecionarNomesPeculiaridades(term,"cap"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompletePericia(string term)
        {
            return Json(new PeculiaridadeDao().SelecionarNomesPeculiaridades(term, "per"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteDesvantagem(string term)
        {
            return Json(new PeculiaridadeDao().SelecionarNomesPeculiaridades(term, "des"), JsonRequestBehavior.AllowGet);
        }
    }
}
