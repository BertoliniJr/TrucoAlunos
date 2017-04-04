using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;
using Truco.Interfaces;

namespace CardGame
{

   public  class Carta : ICartas
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
            set
            {
                naipe = value;
            }
        }

        public int Valor
        {
            set
            {
                valor = value;
            }
        }

        public ICalculoCartas calculo
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        Naipes ICartas.Naipe
        {
            get
            {
                return naipe;
            }
        }

        public override string ToString()
        {
            return $"{this.nomeValor()} de {Naipes}";
        }

        public int getValor()
        {
            return valor; 
        }
    }
}
