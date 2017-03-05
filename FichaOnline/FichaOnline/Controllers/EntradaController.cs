using FichaOnline.Models.DAO;
using FichaOnline.Models.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaOnline.Controllers
{
    public class EntradaController : Controller
    {
        public ActionResult Entrar()
        {
            if (Session["usuario"] != null)
                return RedirectToAction("Inicio", "Desktop");
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(EntraFacade entraUsu)
        {
            try
            {
                var usuario = new UsuarioDao().SelecionarPorEmail(entraUsu.Email);
                if (usuario != null)
                    if (usuario.Senha != entraUsu.Senha)
                    {
                        Session["alert"] = UtilController.RenderAlert("Ops!", "Senha incorreta!", "warning");
                        return View();
                    }
                    else
                    {
                        Session["usuario"] = usuario;
                        return RedirectToAction("Inicio", "Desktop");
                    }
                Session["alert"] = UtilController.RenderAlert("Vish!", "Não há cadastro com este e-mail!", "warning");
                return View();
            }
            catch (Exception ex)
            {
                Session["alert"] = UtilController.RenderAlert("Erro!", "Erro no servidor, por favor tente novamente (agora ou mais tarde). Relatório: <br>" + ex.Message, "danger");
                return View();
            }
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadaFacade cadaUsu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new UsuarioDao().Inserir(cadaUsu.Usuario);
                    Session["alert"] = UtilController.RenderAlert("Parabéns!", "Você foi cadastrado com sucesso, pelo e-mail " + cadaUsu.Email + "!", "success");
                    return View("Entrar");
                }
                catch (Exception ex)
                {
                    Session["alert"] = UtilController.RenderAlert("Erro!", "Erro ao tentar cadastrar. Mas a culpa não é sua! Erro: " + ex.Message, "danger");
                    return View();
                }
            }
            Session["alert"] = UtilController.RenderAlert("Ops!", "Preencha os campos corretamente e não deixe os obrigatórios em branco.", "warning");
            return View();
        }

        public ActionResult EmailUnico(string email)
        {
            var emails = new List<string>();
            var todos = new UsuarioDao().Listar();
            foreach (var u in todos)
                emails.Add(u.Email);

            return Json(emails.All(e => e.ToLower() != email.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}
