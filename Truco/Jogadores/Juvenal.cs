using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;
using Truco.Enumeradores;

namespace CardGame
{
    class Juvenal : Jogador
    {
        private List<ICartas> ICartassJogadas;

        public Juvenal(string n, Log logar) : base(n, logar)
        {
            ICartassJogadas = new List<ICartas>();
        }
        public override ICartas Jogar(List<ICartas> ICartassMesa, ICartas manilha)
        {
            //ordenando
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            ICartas ICartas = _mao[0];
            //primeiro a jogar
            if (ICartassMesa.Count == 0)
            {
                ICartas = primeiroJogar(ICartassMesa, manilha);
            }//segundo a jogar
            else if (ICartassMesa.Count == 1)
            {
                ICartas = segundoJogar(ICartassMesa, manilha);
            } // terceiro a jogar
            else if (ICartassMesa.Count == 2)
            {
                ICartas = terceiroJogar(ICartassMesa, manilha);
            }// quarto a jogar
            else if (ICartassMesa.Count == 3)
            {
                ICartas = quartoJogar(ICartassMesa, manilha);
            }

            return ICartas;
        }
        

        public ICartas primeiroJogar(List<ICartas> ICartassMesa, ICartas manilha)
        {
            ICartas ICartas = _mao.Last();
            _mao.Remove(_mao.Last());
            return ICartas;
        }
        public ICartas segundoJogar(List<ICartas> ICartassMesa, ICartas manilha)
        {
            ICartas ICartas = _mao[0];
            for (int i = 0; i < _mao.Count; i++)
            {
                if (TrucoAuxiliar.compara(_mao[i], ICartassMesa[0], manilha) > 0)
                {
                    ICartas = _mao[i];
                    _mao.RemoveAt(i);
                    break;
                }
            }

            return ICartas;
        }
        public ICartas terceiroJogar(List<ICartas> ICartassMesa, ICartas manilha)
        {
            ICartas ICartas = _mao[0];
            if (TrucoAuxiliar.gerarValorICartas(ICartassMesa[0], manilha) > TrucoAuxiliar.gerarValorICartas(ICartassMesa[1], manilha))
            {
                ICartas = _mao[0];
                _mao.RemoveAt(0);
            }
            else
            {
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.compara(_mao[i], ICartassMesa[1], manilha) > 0)
                    {
                        ICartas = _mao[i];
                        _mao.RemoveAt(i);
                        break;
                    }
                }
            }
            return ICartas;
        }
        public ICartas quartoJogar(List<ICartas> ICartassMesa, ICartas manilha)
        {
            ICartas ICartas = _mao[0];
            if (TrucoAuxiliar.gerarValorICartas(ICartassMesa[1], manilha) > TrucoAuxiliar.gerarValorICartas(ICartassMesa[0], manilha) && TrucoAuxiliar.gerarValorICartas(ICartassMesa[1], manilha) > TrucoAuxiliar.gerarValorICartas(ICartassMesa[2], manilha))
            {
                ICartas = _mao[0];
                _mao.RemoveAt(0);
            }
            else
            {
                ICartas maior = null;
                if (TrucoAuxiliar.gerarValorICartas(ICartassMesa[0], manilha) > TrucoAuxiliar.gerarValorICartas(ICartassMesa[2], manilha))
                {
                    maior = ICartassMesa[0];
                }
                else
                {
                    maior = ICartassMesa[2];
                }
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.compara(_mao[i], maior, manilha) > 0)
                    {
                        ICartas = _mao[i];
                        _mao.RemoveAt(i);
                        break;
                    }
                }
            }
            return ICartas;
        }
        public override void novaICartas(ICartas ICartas, Jogador jogador, ICartas manilha)
        {
            if(ICartassJogadas.Count == 4  || ICartassJogadas.Count == 0)
            {
                ICartassJogadas = new List<ICartas>();
            }
            ICartassJogadas.Add(ICartas);
            if ( _mao.Count == 2 && (TrucoAuxiliar.gerarValorICartas(_mao[0],manilha) >=11 || TrucoAuxiliar.gerarValorICartas(_mao[1], manilha) >= 11))
            {
                trucar(this, EnumTruco.truco);
            }else if (_mao.Count == 1 && TrucoAuxiliar.gerarValorICartas(_mao[0], manilha) >= 11)
            {
                trucar(this, EnumTruco.truco);
            }
        }
        public override Escolha trucado(Jogador trucante, EnumTruco valor, ICartas manilha)
        {
            Escolha escolhi = Escolha.correr;
            for (int i = 0; i < _mao.Count; i++)
            {
                if (_mao[i].valor(manilha) == 14)
                {
                    return Escolha.aumentar;
                }else if (_mao[i].valor(manilha) >= 11)
                {
                    escolhi = Escolha.aceitar;
                }
            }
            return escolhi;
        }
    }
}
