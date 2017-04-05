using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco;
using Truco.Auxiliares;
using Truco.Enumeradores;
using Truco.Interfaces;
using Truco.Jogar;

namespace CardGame
{
    class Jogador:IJogador
    {
        //public event trucoseubosta truco;
        //public delegate void trucoseubosta(Jogador jogador, EnumTruco truco);

        public IJogar joga { get; set; }

        protected List<ICartas> _mao;
        protected string _nome;
        private int _idEquipe;
        public string nome
        {
            get
            {
                return _nome;
            }

        }
        protected Log log;
        public int IDEquipe
        {
            get
            {
                return _idEquipe;
            }

            set
            {
                _idEquipe = value;
            }
        }

        public IEquipe equipe { get; set; }

        public Jogador(string n)
        {
            _nome = n;
            _mao = new List<ICartas>();
            verificaJogada();
        }

        //public virtual Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        //{
        //    // encontra maior da mesa
        //    if (_mao.Count == 3)
        //    {
        //        ordenar(manilha);
        //    }
        //    Carta maiorMesa = cartasRodada.LastOrDefault();
        //    for (int i = 0; i < cartasRodada.Count - 1; i++)
        //    {
        //        if (TrucoAuxiliar.comparar(cartasRodada[i], maiorMesa, manilha) > 0)
        //        {
        //            maiorMesa = cartasRodada[i];
        //        }
        //    }
        //    //descarta
        //    Carta carta = _mao[0];
        //    if (maiorMesa == null)
        //    {
        //        _mao.RemoveAt(0);
        //        return carta;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < _mao.Count; i++)
        //        {
        //            carta = _mao[i];
        //            if (TrucoAuxiliar.comparar(carta, maiorMesa, manilha) > 0)
        //            {
        //                _mao.RemoveAt(i);
        //                return carta;
        //            }
        //        }
        //        carta = _mao[0];
        //        _mao.RemoveAt(0);
        //        return carta;
        //    }
        //}

        //protected void ordenar(ICartas manilha)
        //{
        //    _mao = _mao.OrderBy(x => TrucoAuxiliar.gerarValorICartas(x, manilha)).ToList();
        //}

        public void ReceberCarta(ICartas c)
        {
            _mao.Add(c);
        }

        public virtual void novaMao()
        {
            _mao = new List<ICartas>();
        }

        //public virtual void novaCarta(ICartas carta, Jogador jogador, ICartas manilha)
        //{
        //    if (jogador.IDEquipe != IDEquipe
        //        && ((ICartas)carta).valor(manilha) < 2
        //        && _mao.Count > 0
        //        && _mao.Max(a => a.valor(manilha)) > 10)
        //        truco(this, EnumTruco.truco);
        //}

        //public virtual Escolha trucado(Jogador trucante, EnumTruco valor, ICartas manilha)
        //{
        //    return Escolha.aceitar;
        //}

        public override string ToString()
        {
            return this.nome;
        }

        //protected void trucar (Jogador jogador, EnumTruco pedido)
        //{
        //    truco(jogador, pedido);
        //}

        private void verificaJogada()
        {
            switch (Jogo.getJogo().tipoJogo)
            {
                case EnumTipoJogo.truco:
                    joga = new JogarTruco(this, _mao);
                    break;
                case EnumTipoJogo.poker:
                    joga = new JogarPoker(this, _mao);
                    break;
                case EnumTipoJogo.malmal:
                    joga = new JogarMalMal(this, _mao);
                    break;
                case EnumTipoJogo.buraco:
                    joga = new JogarBuraco(this, _mao);
                    break;
                case EnumTipoJogo.pife:
                    joga = new JogarPife(this, _mao);
                    break;
                default:
                    break;
            }
        }

        public ICartas jogar()
        {
            verificaJogada();
            return joga.jogar();
        }

        public void receberCarta(ICartas carta)
        {
            _mao.Add(carta);
        }
    }
}


