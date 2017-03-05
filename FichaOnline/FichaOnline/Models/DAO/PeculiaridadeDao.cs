using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.DAO
{
    public class PeculiaridadeDao
    {
        public void Inserir(Peculiaridade peculiaridade)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    foc.PeculiaridadeSet.Add(peculiaridade);
                    foc.SaveChanges();
                }
                catch (Exception ex)
                {                    
                    throw new Exception("[PeculiaridadeDao.Inserir] -> " + ex.Message);
                }
            }
        }

        public List<Peculiaridade> ListarPorFichaIdETipo(int fichaid, string tipo)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PeculiaridadeSet.Where(p => p.FichaId == fichaid && p.Tipo == tipo).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PeculiaridadeDao.ListarPorFichaIdETipo] -> " + ex.Message);
                }
            }
        }

        public List<Peculiaridade> ListarPorTipo(string tipo)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PeculiaridadeSet.Where(p => p.Tipo == tipo).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PeculiaridadeDao.ListarPorTipo] -> " + ex.Message);
                }
            }
        }

        public Peculiaridade SelecionarPorId(int id)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PeculiaridadeSet.Where(p => p.Id == id).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PeculiaridadeDao.SelecionarPorId] -> " + ex.Message);
                }
            }
        }

        public void Atualizar(Peculiaridade peculiaridade)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    var pec = foc.PeculiaridadeSet.Where(p => p.Id == peculiaridade.Id).SingleOrDefault();
                    pec.Nome = peculiaridade.Nome;
                    pec.Descricao = peculiaridade.Descricao;
                    pec.Teste = peculiaridade.Teste;
                    foc.SaveChanges();
                }
                catch (Exception ex)
                {                    
                    throw new Exception("[PeculiaridadeDao.Atualizar] -> " + ex.Message);
                }
            }
        }

        public List<string> SelecionarNomesPeculiaridades(string term, string tipo)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.PeculiaridadeSet.Where(p => p.Nome.StartsWith(term) || p.Descricao.Contains(term)).Where(p => p.Tipo == tipo).Select(p => p.Nome).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[PeculiaridadeDao.SelecionarNomesPeculiaridades] -> " + ex.Message);
                }
            }
        }
    }
}