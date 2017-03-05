using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.Facade
{
    public class EntraFacade
    {
        public Usuario Usuario { get; set; }

        public EntraFacade()
        {
            this.Usuario = new Usuario();
        }

        [Required(ErrorMessage = "É necessário informar seu e-mail!")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O E-mail informado năo é válido!")]
        public string Email
        {
            get
            {
                return Usuario.Email;
            }
            set
            {
                Usuario.Email = value;
            }
        }

        [Required(ErrorMessage = "É necessário informar sua senha!")]
        public string Senha
        {
            get
            {
                return Usuario.Senha;
            }
            set
            {
                Usuario.Senha = value;
            }
        }
    }
}