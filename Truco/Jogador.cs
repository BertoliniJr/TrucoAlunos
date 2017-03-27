using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Jogador
    {
        public event EventHandler truco;
        public virtual void novaCarta(object carta, EventArgs e)
        {
            if (((Carta)carta).Valor == 0)
                truco(this, EventArgs.Empty);
        }
        public virtual void trucado(Jogador trucante, int valor)
        {
            
        }

        protected List<Carta> _mao;
        protected string _nome;
        protected int IDequipe;
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

        public virtual Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            // encontra maior da mesa
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            Carta maiorMesa = cartasRodada.LastOrDefault();
            for (int i = 0; i < cartasRodada.Count - 1; i++)
            {
                if (TrucoAuxiliar.comparar(cartasRodada[i], maiorMesa, manilha) > 0)
                {
                    maiorMesa = cartasRodada[i];
                }
            }
            //descarta
            Carta carta = _mao[0];
            if (maiorMesa == null)
            {
                _mao.RemoveAt(0);
                return carta;

            }
            else
            {
                for (int i = 0; i < _mao.Count; i++)
                {
                    carta = _mao[i];
                    if (TrucoAuxiliar.comparar(carta, maiorMesa, manilha) > 0)
                    {
                        _mao.RemoveAt(i);
                        return carta;
                    }
                }
                carta = _mao[0];
                _mao.RemoveAt(0);
                return carta;
            }
        }

        protected void ordenar(Carta manilha)
        {
            _mao = _mao.OrderBy(x => TrucoAuxiliar.gerarValorCarta(x, manilha)).ToList();
        }

        public void ReceberCarta(Carta c)
        {
            _mao.Add(c);
        }
    }
}


