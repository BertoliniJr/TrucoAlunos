using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Jogador
    {
        public event trucoseubosta truco;
        public delegate void trucoseubosta(Jogador jogador, Truco truco);
        public virtual void novaCarta(Carta carta, Jogador jogador)
        {
            if (jogador.IDEquipe != this.IDEquipe 
                && ((Carta)carta).valor(manilha) < 2 
                && _mao.Max(a => a.valor(manilha)) > 10)
                truco(this, Truco.truco);
        }
        public virtual Escolha trucado(Jogador trucante, Truco valor)
        {
            return Escolha.aceitar;
        }

        protected List<Carta> _mao;
        protected string _nome;
        protected int IDequipe;
        protected Carta manilha;
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

        public virtual Carta Jogar(List<Carta> cartasRodada, Carta manilhaParametro)
        {
            manilha = manilhaParametro;
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
        public void NovaMao()
        {
            _mao = new List<Carta>();
        }
    }
}


