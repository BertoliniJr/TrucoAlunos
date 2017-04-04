using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;
using Truco.Enumeradores;

namespace CardGame
{
    class Jogador
    {
        public event trucoseubosta truco;
        public delegate void trucoseubosta(Jogador jogador, EnumTruco truco);        

        protected List<ICartas> _mao;
        protected string _nome;
        private int _idEquipe;
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
        
        public Jogador(string n, Log logar)
        {
            nome = n;
            _mao = new List<ICartas>();
            log = logar;
        }

        public virtual ICartas Jogar(List<ICartas> ICartassRodada, ICartas manilha)
        {
            // encontra maior da mesa
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            ICartas maiorMesa = ICartassRodada.LastOrDefault();
            for (int i = 0; i < ICartassRodada.Count - 1; i++)
            {
                if (TrucoAuxiliar.comparar(ICartassRodada[i], maiorMesa, manilha) > 0)
                {
                    maiorMesa = ICartassRodada[i];
                }
            }
            //desICartas
            ICartas ICartas = _mao[0];
            if (maiorMesa == null)
            {
                _mao.RemoveAt(0);
                return ICartas;
            }
            else
            {
                for (int i = 0; i < _mao.Count; i++)
                {
                    ICartas = _mao[i];
                    if (TrucoAuxiliar.comparar(ICartas, maiorMesa, manilha) > 0)
                    {
                        _mao.RemoveAt(i);
                        return ICartas;
                    }
                }
                ICartas = _mao[0];
                _mao.RemoveAt(0);
                return ICartas;
            }
        }

        protected void ordenar(ICartas manilha)
        {
            _mao = _mao.OrderBy(x => TrucoAuxiliar.gerarValorICartas(x, manilha)).ToList();
        }

        public void ReceberICartas(ICartas c)
        {
            _mao.Add(c);
        }

        public virtual void NovaMao()
        {
            _mao = new List<ICartas>();
        }

        public virtual void novaICartas(ICartas ICartas, Jogador jogador, ICartas manilha)
        {
            if (jogador.IDEquipe != IDEquipe
                && ((ICartas)ICartas).valor(manilha) < 2
                && _mao.Count > 0
                && _mao.Max(a => a.valor(manilha)) > 10)
                truco(this, EnumTruco.truco);
        }

        public virtual Escolha trucado(Jogador trucante, EnumTruco valor, ICartas manilha)
        {
            return Escolha.aceitar;
        }

        public override string ToString()
        {
            return this.nome;
        }

        protected void trucar (Jogador jogador, EnumTruco pedido)
        {
            truco(jogador, pedido);
        }
    }
}


