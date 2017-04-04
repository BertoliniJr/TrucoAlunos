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
                    string valor = "";
                    if (i == 1) valor = "A";
                    else if (i == 12) valor = "J";
                    else if (i == 11) valor = "Q";
                    else if (i == 13) valor = "K";
                    else valor = i.ToString();
                    ICartas c1 = new Carta(Naipes.copas, valor);
                    ICartas c2 = new Carta(Naipes.espadas, valor);
                    ICartas c3 = new Carta(Naipes.ouros, valor);
                    ICartas c4 = new Carta(Naipes.paus, valor);
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
