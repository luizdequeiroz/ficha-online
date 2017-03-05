using FichaOnline.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FichaOnline.Models.Facade
{
    public class FichaFacade
    {
        public Ficha Ficha { get; set; }

        public FichaFacade()
        {
            this.Ficha = new Ficha();
        }

        public FichaFacade(Ficha ficha)
        {
            this.Ficha = ficha;
        }

        [Required]
        public string Nome
        {
            get
            {
                return Ficha.Nome;
            }
            set
            {
                Ficha.Nome = value;
            }
        }

        public int Idade
        {
            get
            {
                return Ficha.Idade;
            }
            set
            {
                Ficha.Idade = value;
            }
        }

        public string Classe
        {
            get
            {
                return Ficha.Classe;
            }
            set
            {
                Ficha.Classe = value;
            }
        }

        public string Raca
        {
            get
            {
                return Ficha.Raca;
            }
            set
            {
                Ficha.Raca = value;
            }
        }

        [Required]
        public int Adre
        {
            get
            {
                return Ficha.Adre;
            }
            set
            {
                Ficha.Adre = value;
            }
        }

        [Required]
        public int Ataq
        {
            get
            {
                return Ficha.Ataq;
            }
            set
            {
                Ficha.Ataq = value;
            }
        }

        [Required]
        public int Defe
        {
            get
            {
                return Ficha.Defe;
            }
            set
            {
                Ficha.Defe = value;
            }
        }

        [Required]
        public int Dest
        {
            get
            {
                return Ficha.Dest;
            }
            set
            {
                Ficha.Dest = value;
            }
        }

        [Required]
        public int Forc
        {
            get
            {
                return Ficha.Forc;
            }
            set
            {
                Ficha.Forc = value;
            }
        }

        [Required]
        public int Inte
        {
            get
            {
                return Ficha.Inte;
            }
            set
            {
                Ficha.Inte = value;
            }
        }

        [Required]
        public int Resi
        {
            get
            {
                return Ficha.Resi;
            }
            set
            {
                Ficha.Resi = value;
            }
        }

        [Required]
        public int Sabe
        {
            get
            {
                return Ficha.Sabe;
            }
            set
            {
                Ficha.Sabe = value;
            }
        }

        [Required]
        public int Velo
        {
            get
            {
                return Ficha.Velo;
            }
            set
            {
                Ficha.Velo = value;
            }
        }

        [Required]
        public int Vital
        {
            get
            {
                return Ficha.Vital;
            }
            set
            {
                Ficha.Vital = value;
            }
        }

        [Required]
        public int Sorte
        {
            get
            {
                return Ficha.Sorte;
            }
            set
            {
                Ficha.Sorte = value;
            }
        }

        public string Nota
        {
            get
            {
                return Ficha.Nota;
            }
            set
            {
                Ficha.Nota = value;
            }
        }

        public int Experiencia
        {
            get
            {
                return Ficha.Experiencia;
            }
            set
            {
                Ficha.Experiencia = value;
            }
        }

        [RegularExpression(@"\w+([ ]\w+)*(, )+\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Utilize o autocomplete para seguir o padrão '[nome], [email]'!")]
        public string Mestre { get; set; }
        public string Jogador { get; set; }

        public int Pontos
        {
            get
            {
                return Ficha.Pontos;
            }
            set
            {
                Ficha.Pontos = value;
            }
        }

        public int PtsPeculiaridades
        {
            get
            {
                return Ficha.PtsPeculiaridades;
            }
            set
            {
                Ficha.PtsPeculiaridades = value;
            }
        }
    }
}