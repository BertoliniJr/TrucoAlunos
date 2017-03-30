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
        private List<Tuple<Jogador,Carta>> rodada1;
        private List<Tuple<Jogador, Carta>> rodada2;
        private static int pontosRodada = 0;
        private static bool ganhaPrimeira = false;
        private static bool ganhaSegunda = false;
        private int rod = 0;
        
        public IlusionistaDaMesa(string n) : base(n)
        {
        }


        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            rod++;
            rodada1 = new List<Tuple<Jogador, Carta>>();
            rodada2 = new List<Tuple<Jogador, Carta>>();
            Carta aux;
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            ganheiPrimeira(cartasRodada);
            ganheiSegunda(cartasRodada);

            #region UltimaCarta
            if (_mao.Count == 1&&cartasRodada.Count>2 && _mao[0].valor(manilha)>cartasRodada.Max(x=>x.valor(manilha)))
            {
                pedirTruco(this, trucar());
                return jogaMenor();
            }

            if (_mao.Count == 1 && cartasRodada.Count > 3)
            {
                pedirTruco(this, trucar());
                return jogaMenor();
            }
            #endregion

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
                        pedirTruco(this, trucar());
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
        
        /// <summary>
        /// made by Guilherme
        /// </summary>
        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {
            Tuple<Jogador, Carta> t = new Tuple<Jogador, Carta>(jogador,carta);
            if (rod==1)
            {
                rodada1.Add(t);
                return;
            }
            if (rod==2)
            {
                rodada2.Add(t);
                return;
            }
            
        }

        public override Escolha trucado(Jogador trucante, CardGame.Truco valor, Carta manilha)
        {
            if (trucante.IDEquipe == this.IDEquipe)
                return Escolha.aceitar;
            //primeira rodada
            if (_mao.Where(x => x.valor(manilha) >= 10).Count() >= 2)
            {
                return aceitarComZap(manilha, valor);
            }
            //segunda rodada
            if (ganhaPrimeira && _mao.Where(x => x.valor(manilha) >= 9).Count() >= 1)
                return aceitarComZap(manilha, valor);
            //terceira rodada
            if (ganhaSegunda && _mao.Where(x => x.valor(manilha) >= 10).Count() >= 1)
                return aceitarComZap(manilha, valor);
            Console.WriteLine("MUITA CARTA NA MAO DE TONTO, É SÓ UM PONTO");
            return Escolha.correr;
        }

        private CardGame.Truco trucar()
        {
            return (CardGame.Truco)pontosRodada;
        }

        private void trucarNaPrimeira(Carta manilha)
        {
            if (_mao.Where(x => x.valor(manilha) >= 11).Count() >= 2 && _mao.Count() == 3)
            {
                Console.WriteLine(frasesEfeito());
                pedirTruco(this, trucar());
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

        private Escolha aumentar(CardGame.Truco valor)
        {
            pontosRodada = (int)valor;
            return Escolha.aumentar;
        }

        private Escolha aceitarComZap(Carta manilha, CardGame.Truco valor)
        {
            if (_mao.Last().valor(manilha) == 14)
            {
                return aumentar(valor);
            }
            return aceitar(valor);
        }

        private void pedirTruco(Jogador jogador, CardGame.Truco pedido)
        {
            if (Equipe.BuscaID(IDEquipe).Adversario.PontosEquipe>=12||Equipe.BuscaID(IDEquipe).PontosEquipe>=12)
            {
                return;
            }
            Console.WriteLine(frasesEfeito());
            base.trucar(jogador, pedido);
        }

        private Carta retornaMaiorCartaIlusionista(List<Tuple<Jogador, Carta>> rodada, Carta manilha)
        {
            var cartasIlusionista = rodada.Where(x => x.Item1.IDEquipe == this.IDEquipe).ToList();
            
            Carta c = cartasIlusionista[0].Item2;

            foreach (var tupla in cartasIlusionista)
            {
                if(TrucoAuxiliar.gerarValorCarta(tupla.Item2, manilha) > TrucoAuxiliar.gerarValorCarta(c, manilha))
                {
                    c = tupla.Item2;
                }
            }
            return c;
        }

        private Carta retornaMaiorCartaAdversario(List<Tuple<Jogador, Carta>> rodada, Carta manilha)
        {
            var cartasAdversario = rodada.Where(x => x.Item1.IDEquipe == this.IDEquipe).ToList();

            Carta c = cartasAdversario[0].Item2;

            foreach (var tupla in cartasAdversario)
            {
                if (TrucoAuxiliar.gerarValorCarta(tupla.Item2, manilha) > TrucoAuxiliar.gerarValorCarta(c, manilha))
                {
                    c = tupla.Item2;
                }
            }
            return c;
        }

        private string frasesEfeito()
        
            Random n = new Random();
            switch (n.Next(5))
            {
                case 1:
                    return "SUBI NO MURO, CAI DE FRENTE, TRUCO SEU DEMENTE!";
                case 2:
                    return "JOGAR TRUCO E MUITO FACIL, PRINCIPALMENTE COM FREGUES. AGORA EU GRITO TRUCO, E QUERO VER QUEM VAI PARA O SEIS";
                case 3:
                    return "SUBI NO MURO E CAI DE LADO, TRUCO SEU VIADO";
                case 4:
                    return "É TRUUUUUUUUCO, LADRÃO!! PEDE SEIS, PEDE!";
                default:
                    return "";
            }
        }
    }
}
