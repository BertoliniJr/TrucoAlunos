using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

   public  class Carta
    {

        Naipes naipe;
        int valor;
   
        public  Carta(Naipes naipe, int valor)
        {
            this.naipe = naipe;
            this.valor = valor;
        }

        public string nomeValor()
        {
            if (valor == 1) return "A";
            else if (valor == 12) return "J";
            else if (valor == 11) return "Q";
            else if (valor == 13) return "K";
            else return Convert.ToString(valor);
        }

        public Naipes Naipe
        {
            get
            {
                return naipe;
            }

            set
            {
                naipe = value;
            }
        }

        public int Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public override string ToString()
        {
            return $"{this.nomeValor()} de {this.Naipe}";
        }
    }
}
