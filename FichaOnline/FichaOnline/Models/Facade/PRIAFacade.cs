using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.Facade
{
    public class PRIAFacade
    {
        public PropriedadeRiquezaItemArma PropriedadeRiquezaItemArma { get; set; }

        public PRIAFacade()
        {
            this.PropriedadeRiquezaItemArma = new PropriedadeRiquezaItemArma();
        }

        public PRIAFacade(PropriedadeRiquezaItemArma pria)
        {
            this.PropriedadeRiquezaItemArma = pria;
        }

        [Required]
        public string Nome
        {
            get
            {
                return PropriedadeRiquezaItemArma.Nome;
            }
            set
            {
                PropriedadeRiquezaItemArma.Nome = value;
            }
        }

        [Required]
        public string Subtipo
        {
            get
            {
                return PropriedadeRiquezaItemArma.Subtipo;
            }
            set
            {
                PropriedadeRiquezaItemArma.Subtipo = value;
            }
        }

        [Required]
        public int PesoQuantidade
        {
            get
            {
                return PropriedadeRiquezaItemArma.PesoQuantidade;
            }
            set
            {
                PropriedadeRiquezaItemArma.PesoQuantidade = value;
            }
        }

        [Required]
        public string Descricao
        {
            get
            {
                return PropriedadeRiquezaItemArma.Descricao;
            }
            set
            {
                PropriedadeRiquezaItemArma.Descricao = value;
            }
        }

        [Required]
        public int ValorDano
        {
            get
            {
                return PropriedadeRiquezaItemArma.ValorDano;
            }
            set
            {
                PropriedadeRiquezaItemArma.ValorDano = value;
            }
        }

        public string Tipo
        {
            get
            {
                return PropriedadeRiquezaItemArma.Tipo;
            }
            set
            {
                PropriedadeRiquezaItemArma.Tipo = value;
            }
        }

        public int FichaId
        {
            get
            {
                return PropriedadeRiquezaItemArma.FichaId;
            }
            set
            {
                PropriedadeRiquezaItemArma.FichaId = value;
            }
        }
    }
}