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
        int peso;
        
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
                return calculo;
            }

            set
            {
                calculo = value;
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
            return $"{this.nomeValor()} de {this.naipe}";
        }

        public int getValor()
        {
            return valor; 

        }

        public int getPeso()
        {
            return peso;
        }

        public void setPeso(ICartas carta)
        {
            this.peso = calculo.getPeso(carta);
        }
    }
}
