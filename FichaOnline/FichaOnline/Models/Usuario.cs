//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FichaOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Fichas = new HashSet<Ficha>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DataCadastro { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public string DataNascimento { get; set; }
    
        public virtual ICollection<Ficha> Fichas { get; set; }
    }
}
