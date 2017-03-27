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
    }

    
}
