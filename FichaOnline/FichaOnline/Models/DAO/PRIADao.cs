using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.DAO
{
    public class PRIADao
    {

        public void Inserir(PropriedadeRiquezaItemArma pria)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    foc.PropriedadeRiquezaItemArmaSet.Add(pria);
                    foc.SaveChanges();
                }
                catch (Exception ex)
                {                    
                    throw new Exception("[PRIADao.Inserir] -> " + ex.Message);
                }
            }
        }

        public List<PropriedadeRiquezaItemArma> ListarPorTipo(string tipo)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PropriedadeRiquezaItemArmaSet.Where(p => p.Tipo == tipo).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PRIAao.ListarPorTipo] -> " + ex.Message);
                }
            }
        }

        public List<PropriedadeRiquezaItemArma> ListarPorFichaIdETipo(int fichaid, string tipo)
        {
            using (var foc = new FichaOnlineContainer()) 
            {
                try
                {
                    return foc.PropriedadeRiquezaItemArmaSet.Where(p => p.FichaId == fichaid && p.Tipo == tipo).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PRIADao.ListarPorFichaIdETipo] -> " + ex.Message);
                }
            }
        }

        public void Atualizar(PropriedadeRiquezaItemArma pria)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    var prop = foc.PropriedadeRiquezaItemArmaSet.Where(p => p.Id == pria.Id).SingleOrDefault();
                    prop.Nome = pria.Nome;
                    prop.Subtipo = pria.Subtipo;
                    prop.PesoQuantidade = pria.PesoQuantidade;
                    prop.Descricao = pria.Descricao;
                    prop.ValorDano = pria.ValorDano;
                    foc.SaveChanges();
                }
                catch (Exception ex)
                {                    
                    throw new Exception("[PRIADao.Atualizar] -> " + ex.Message);
                }
            }
        }

        public PropriedadeRiquezaItemArma SelecionarPorId(int id) 
        {
             using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PropriedadeRiquezaItemArmaSet.Where(p => p.Id == id).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PRIADao.ListarPorId] -> " + ex.Message);
                }
            }
        }

        public List<string> SelecionarDescricoesPropriedadeRiqueza(string term, string tipo)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PropriedadeRiquezaItemArmaSet.Where(p => p.Descricao.StartsWith(term)).Where(p => p.Tipo == tipo).Select(p => p.Descricao).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PRIADao.SelecionarDescricoesPropriedadeRiqueza] -> " + ex.Message);
                }
            }
        }

        public List<string> SelecionarSubtipo(string term, string tipo)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PropriedadeRiquezaItemArmaSet.Where(p => p.Subtipo.StartsWith(term)).Where(p => p.Tipo == tipo).Select(p => p.Subtipo).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PRIADao.SelecionarSubtipo] -> " + ex.Message);
                }
            }
        }
    }
}