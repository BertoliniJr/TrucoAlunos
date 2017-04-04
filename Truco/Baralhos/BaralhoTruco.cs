using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;
using CardGame;
using Truco.Enumeradores;

namespace Truco.Baralhos
{
    class BaralhoTruco : IBaralho
    {
        public List<ICartas> baralho = new List<ICartas>();

        public BaralhoTruco()
        {
            criarBaralho();
        }

        private void criarBaralho()
        {
            baralho = new List<ICartas>();
            for (int i = 1; i <= 13; i++)
            {
                if (i != 8 && i != 9 && i != 10)
                {
                    ICartas c1 = new Carta(Naipes.copas, i);
                    c1.setPeso(c1);
                    ICartas c2 = new Carta(Naipes.espadas, i);
                    c2.setPeso(c2);
                    ICartas c3 = new Carta(Naipes.ouros, i);
                    c3.setPeso(c3);
                    ICartas c4 = new Carta(Naipes.paus, i);
                    c4.setPeso(c4);

                    baralho.Add(c1);
                    baralho.Add(c2);
                    baralho.Add(c3);
                    baralho.Add(c4);
                }
            }
        }

        public void embaralhar()
        {
            baralho.Shuffle();
        }

        public void recolher()
        {
            criarBaralho();
        }

        public ICartas pegarProxima()
        {
            ICartas aux;
            aux = baralho[0];
            baralho.RemoveAt(0);
            return aux;
        }


    }

}
