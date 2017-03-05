using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FichaOnline.Models.Facade
{
    public class CadaFacade
    {
        public Usuario Usuario { get; set; }

        public CadaFacade()
        {
            this.Usuario = new Usuario();
        }

        [Required(ErrorMessage = "É necessário informar seu nome!")]
        public string Nome
        {
            get
            {
                return Usuario.Nome;
            }
            set
            {
                Usuario.Nome = value;
            }
        }
        [Required(ErrorMessage = "É necessário informar seu e-mail!")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O E-mail informado năo é válido!")]
        [Remote("EmailUnico", "Entrada", ErrorMessage = "Alguém já está usando este e-mail!")]
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

        [Required(ErrorMessage = "É necessário confirmar sua senha!")]
        [System.Web.Mvc.Compare("Senha", ErrorMessage = "A confirmação não confere com a senha!")]
        public string RepSenha { get; set; }

        [Required(ErrorMessage = "É necessário informar sua pergunta!")]
        public string Pergunta
        {
            get
            {
                return Usuario.Pergunta;
            }
            set
            {
                Usuario.Pergunta = value;
            }
        }

        [Required(ErrorMessage = "É necessário informar sua resposta!")]
        public string Resposta
        {
            get
            {
                return Usuario.Resposta;
            }
            set
            {
                Usuario.Resposta = value;
            }
        }

        [Required(ErrorMessage = "É necessário informar sua data de nascimento!")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", 
            ErrorMessage = "A data de nascimento informada năo é válida!")]
        public string DataNascimento
        {
            get
            {
                return Usuario.DataNascimento;
            }
            set
            {
                Usuario.DataNascimento = value;
            }
        }
    }
}