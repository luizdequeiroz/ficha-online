using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.Facade
{
    public class PeculFacade
    {
        public Peculiaridade Peculiaridade { get; set; }

        public PeculFacade()
        {
            this.Peculiaridade = new Peculiaridade();
        }

        public PeculFacade(Peculiaridade peculiaridade)
        {
            this.Peculiaridade = peculiaridade;
        }

        [Required]
        public string Nome
        {
            get
            {
                return Peculiaridade.Nome;
            }
            set
            {
                Peculiaridade.Nome = value;
            }
        }

        [Required]
        public string Descricao
        {
            get
            {
                return Peculiaridade.Descricao;
            }
            set
            {
                Peculiaridade.Descricao = value;
            }
        }

        [Required]
        public int Teste
        {
            get
            {
                return Peculiaridade.Teste;
            }
            set
            {
                Peculiaridade.Teste = value;
            }
        }

        public string Tipo
        {
            get
            {
                return Peculiaridade.Tipo;
            }
            set
            {
                Peculiaridade.Tipo = value;
            }
        }

        public int FichaId
        {
            get
            {
                return Peculiaridade.FichaId;
            }
            set
            {
                Peculiaridade.FichaId = value;
            }
        }
    }
}