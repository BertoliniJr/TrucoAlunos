using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    class Baralho
    {
        public List<Carta> baralho = new List<Carta>();

        public Baralho()
        {
            criarBaralho();
        }

        private void criarBaralho() {
            baralho = new List<Carta>();
            for (int i = 1; i <= 13; i++) {

                if (i != 8 && i != 9 && i != 10) {
                    Carta c1 = new Carta(Naipes.copas, i);
                    Carta c2 = new Carta(Naipes.espadas, i);
                    Carta c3 = new Carta(Naipes.ouros, i);
                    Carta c4 = new Carta(Naipes.paus, i);
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

        public Carta pegarProxima()
        {
            Carta aux;
            aux = baralho[0];
            baralho.RemoveAt(0);
            return aux;
        }
    }


  

    }
