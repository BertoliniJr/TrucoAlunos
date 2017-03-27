using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Jogador
    {

        private List<Carta> _mao;
        private string _nome;
        private int IDequipe;
        public string nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        public int IDEquipe
        {
            get
            {
                return IDequipe;
            }

            set
            {
                IDequipe = value;
            }
        }

        public Jogador(string n)
        {
            nome = n;
            _mao = new List<Carta>();
        }
        static public int comparar(Carta a, Carta b, Carta manilha)
        {
            return 0;
        }
        public Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            // encontra maior da mesa
            if(_mao.Count == 3)
            {
                ordenar(manilha);
            }
            Carta maiorMesa = cartasRodada[cartasRodada.Count ];
            for (int i = 0; i < cartasRodada.Count - 1; i++)
            {
                if (comparar(cartasRodada[i], maiorMesa, manilha) > 0)
                {
                    maiorMesa = cartasRodada[i];
                }
            }
            //descarta
            Carta carta = _mao[0];
            for (int i = 0; i < _mao.Count; i++)
            {
                carta = _mao[i];
                if (comparar(carta, maiorMesa, manilha) > 0)
                {
                    _mao.RemoveAt(i);
                    return carta;
                }

            }
            carta = _mao[0];
            _mao.RemoveAt(0);
            return carta;
        }
        public void ordenar(Carta manilha)
        {
            _mao = _mao.OrderBy(x => TrucoAuxiliar.gerarValorCarta(x, manilha)).ToList();
        }
        
        public void ReceberCarta(Carta c)
        {
            _mao.Add(c);
        }
    }


}


