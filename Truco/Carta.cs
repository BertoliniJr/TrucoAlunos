using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;
using Truco.Interfaces;

namespace CardGame
{

   public  class Carta:ICartas
    {

        Naipes naipe;
        string valor;
   
        public  Carta(Naipes naipe, string valor)
        {
            this.naipe = naipe;
            this.valor = valor;
        }

        public string nomeValor()
        {
            if (valor == "1") return "A";
            else if (valor == "12") return "J";
            else if (valor == "11") return "Q";
            else if (valor == "13") return "K";
            else return Convert.ToString(valor);
        }

        public Naipes Naipe
        {
            set
            {
                naipe = value;
            }
        }

        public string Valor
        {
            set
            {
                valor = value;
            }
        }

        public override string ToString()
        {
            return $"{this.nomeValor()} de {this.Naipe}";
        }

        public Naipes getNaipe()
        {
            return naipe;
        }

        public ICalculoCartas getCalculo()
        {
            return null;
        }

        public string getValor()
        {
            return valor;
        }
    }
}
