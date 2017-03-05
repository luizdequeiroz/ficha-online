using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.DAO
{
    public class UsuarioDao
    {
        public void Inserir(Usuario usuario)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    usuario.DataCadastro = DateTime.Now.ToString();
                    foc.UsuarioSet.Add(usuario);
                    foc.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("[UsuarioDao.Inserir] -> " + ex.Message);
                }
            }
        }

        public Usuario SelecionarPorEmail(string email)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.UsuarioSet.Where(u => u.Email == email).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("[UsuarioDao.SelecionarPorEmail] -> " + ex.Message);
                }
            }
        }

        public List<Usuario> Listar()
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.UsuarioSet.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[UsuarioDao.Listar] -> " + ex.Message);
                }
            }
        }

        public List<string> SelecionarMestres(string str)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    return foc.UsuarioSet.Where(u => u.Nome.StartsWith(str) || u.Email.StartsWith(str)).Select(u => u.Nome + ", " + u.Email).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("[UsuarioDao.SelecionarMestres] -> " + ex.Message);
                }
            }
        }

        public Usuario SelecionarPorId(int? id)
        {
            using (var foc = new FichaOnlineContainer())
            {
                try
                {
                    if (id != null)
                        return foc.UsuarioSet.Where(u => u.Id == id).SingleOrDefault();
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("[UsuarioDao.SelecionarPorId] -> " + ex.Message);
                }
            }
        }
    }
}