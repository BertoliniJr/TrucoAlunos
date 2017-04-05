using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;
using CardGame;
using Truco.Enumeradores;
using Truco.CalculoCarta;

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
                    c1.calculo = new CalculoCartasTruco();
                    ICartas c2 = new Carta(Naipes.espadas, i);
                    c2.calculo = new CalculoCartasTruco();
                    ICartas c3 = new Carta(Naipes.ouros, i);
                    c3.calculo = new CalculoCartasTruco();
                    ICartas c4 = new Carta(Naipes.paus, i);
                    c4.calculo = new CalculoCartasTruco();

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
