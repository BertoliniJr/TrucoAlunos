using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;
using Truco.Enumeradores;
using CardGame;

namespace Truco.Baralhos
{
    class BaralhoPife
    {
        public List<ICartas> baralho = new List<ICartas>();

        public BaralhoPife()
        {
            criarBaralho();
        }

        private void criarBaralho()
        {
            baralho = new List<ICartas>();
            int contador = 0;

            while (contador < 2)
            {
                for (int i = 1; i <= 13; i++)
                {
                    ICartas c1 = new Carta(Naipes.copas, i);
                    ICartas c2 = new Carta(Naipes.espadas, i);
                    ICartas c3 = new Carta(Naipes.ouros, i);
                    ICartas c4 = new Carta(Naipes.paus, i);
                    baralho.Add(c1);
                    baralho.Add(c2);
                    baralho.Add(c3);
                    baralho.Add(c4);
                }
                contador++;
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
