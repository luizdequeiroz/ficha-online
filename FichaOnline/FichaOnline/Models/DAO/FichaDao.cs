using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.DAO
{
    public class FichaDao
    {
        public Ficha SelecionarPorId(int id)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.FichaSet.Where(f => f.Id == id).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.SelecionarPorId] -> " + ex.Message);
                }
            }
        }

        public List<Ficha> ListarPorUsuarioId(int usuarioId)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.FichaSet.Where(f => f.UsuarioId == usuarioId && f.Pontos >= 0).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.ListarPorUsuarioId] -> " + ex.Message);
                }
            }
        }

        public List<Ficha> ListarPorMestreId(int mestreId)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.FichaSet.Where(f => f.MestreId == mestreId && f.UsuarioId != mestreId && f.Pontos >= 0).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.ListarPorMestreId] -> " + ex.Message);
                }
            }
        }

        public List<string> SelecionarNomesClasses(string str)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.FichaSet.Where(f => f.Classe.StartsWith(str)).Select(f => f.Classe).Distinct().ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.SelecionarNomesClasses] -> " + ex.Message);
                }
            }
        }

        public List<string> SelecionarNomesRacas(string str)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.FichaSet.Where(f => f.Raca.StartsWith(str)).Select(f => f.Raca).Distinct().ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.SelecionarNomesRacas] -> " + ex.Message);
                }
            }
        }

        public List<Ficha> Listar()
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.FichaSet.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.Listar] -> " + ex.Message);
                }
            }
        }

        public void Inserir(Ficha ficha)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    if (ficha.Nota == null) ficha.Nota = "";
                    foc.FichaSet.Add(ficha);
                    foc.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.Inserir] -> " + ex.Message);
                }
            }
        }

        public void Atualizar(Ficha ficha)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    var fic = foc.FichaSet.Where(f => f.Id == ficha.Id).SingleOrDefault();
                    var props = ficha.GetType().GetProperties();
                    foreach (var p in props)
                    {
                        if (p.Name != "Peculiaridades" && p.Name != "PropriedadesRiquezasItensArmas" && p.Name != "Usuario")
                            if (p.GetValue(ficha, null) != null && p.GetValue(fic, null) != null)
                            {
                                var value = p.GetValue(ficha, null).ToString();
                                if (value != p.GetValue(fic, null).ToString())
                                    p.SetValue(fic, p.GetValue(ficha, null), null);
                            }
                            else if (p.Name == "MestreId") fic.MestreId = ficha.MestreId;
                    }
                    foc.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("[FichaDao.Atualizar] -> " + ex.Message);
                }
            }
        }
    }
}