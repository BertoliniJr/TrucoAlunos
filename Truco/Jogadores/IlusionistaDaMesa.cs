using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;

namespace Truco
{
    class IlusionistaDaMesa : Jogador
    {

        private static int pontosRodada = 0;
        private static bool ganhaPrimeira = false;
        private static bool ganhaSegunda = false;

        public IlusionistaDaMesa(string n) : base(n)
        {
        }


        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            Carta aux;
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            //ultima carta da mao
            if (_mao.Count == 1)
            {
                return jogaMenor();
            }
            ganheiPrimeira(cartasRodada);
            ganheiSegunda(cartasRodada);
            #region PrimeiroAjogar
            if (cartasRodada.LastOrDefault() == null)
            {
                //Primeira Rodada
                trucarNaPrimeira(manilha);
                if (_mao.Count() == 3)
                {
                    if (_mao.Where(x => x.valor(manilha) >= 13).Count() >= 2)
                        return jogaMenor();
                    else
                        return _mao[1];
                }
                //Segunda Rodada
                if (_mao.Count() == 2)
                {
                    return jogaMenor();
                }
                return jogaMenor();
            }
            #endregion

            #region SegundoAjogar
            if (cartasRodada.Count == 1)
            {
                //segundo da primeira rodada
                trucarNaPrimeira(manilha);

                if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) < 7)
                {
                    Console.WriteLine("Faz ai parceiro.");
                    return jogaMenor();
                }
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) < TrucoAuxiliar.gerarValorCarta(_mao[i], manilha))
                    {
                        aux = _mao[i];
                        _mao.RemoveAt(i);
                        return aux;
                    }
                }
            }
            #endregion

            #region TerceiroAjogar
            if (cartasRodada.Count == 2)
            {
                trucarNaPrimeira(manilha);

                if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) > TrucoAuxiliar.gerarValorCarta(_mao.Last(), manilha))
                {
                    return jogaMenor();
                }
                aux = _mao[0];
                //aux = (Carta)_mao.Where(x=>x.Valor==_mao.Max(y=>y.Valor)&&x.Valor<11);
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.gerarValorCarta(_mao[i], manilha) < 11)
                    {
                        aux = _mao[i];
                    }
                }
                _mao.Remove(aux);
                return aux;
            }
            #endregion

            #region Pe
            trucarNaPrimeira(manilha);

            for (int i = 0; i < _mao.Count; i++)
            {
                if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) < TrucoAuxiliar.gerarValorCarta(_mao[i], manilha) && TrucoAuxiliar.gerarValorCarta(cartasRodada[cartasRodada.Count - 2], manilha) != cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)))
                {
                    aux = _mao[i];
                    if (_mao.Last() != aux && _mao.Last().valor(manilha) >= 10)
                    {
                        trucar(this, trucar());
                        _mao.Remove(aux);
                        return aux;
                    }
                    else
                    {
                        _mao.Remove(aux);
                        return aux;
                    }
                }
            }
            return jogaMenor();
            #endregion
        }

        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {
        }

        public override Escolha trucado(Jogador trucante, CardGame.Truco valor, Carta manilha)
        {
            if ((int)valor > 0)
                return Escolha.correr;
            if (_mao.Where(x => x.valor(manilha) >= 11).Count() >= 2)
            {
                return aceitar(valor);
            }
            if (ganhaPrimeira && _mao.Where(x => x.valor(manilha) >= 10).Count() >= 1)
                return aceitar(valor);
            return base.trucado(trucante, valor,manilha);
        }

        private CardGame.Truco trucar()
        {
            return (CardGame.Truco)pontosRodada;
        }

        private void trucarNaPrimeira(Carta manilha)
        {
            if (_mao.Where(x => x.valor(manilha) >= 11).Count() >= 2 && _mao.Count() == 3)
            {
                Console.WriteLine("SUBI NO MURO, CAI DE FRENTE, TRUCO SEU DEMENTE!");
                trucar(this, trucar());
                pontosRodada++;
            }
        }

        public override void NovaMao()
        {
            base.NovaMao();
            ganhaPrimeira = false;
            ganhaSegunda = false;
            pontosRodada = 0;
        }

        private void ganheiPrimeira(List<Carta> cartasRodada)
        {
            if (_mao.Count==2 && (cartasRodada.Count == 0 || cartasRodada.Count == 2))
            {
                ganhaPrimeira = true;
            }
        }

        private void ganheiSegunda(List<Carta> cartasRodada)
        {
            if (_mao.Count == 1 && (cartasRodada.Count == 0 || cartasRodada.Count == 2))
            {
                ganhaSegunda = true;
            }
        }

        private Carta jogaMenor()
        {
            Carta aux;
            aux = _mao[0];
            _mao.RemoveAt(0);
            return aux;
        }

        private Escolha aceitar(CardGame.Truco valor)
        {
            pontosRodada = (int)valor;
            return Escolha.aceitar;
        }
    }
}
