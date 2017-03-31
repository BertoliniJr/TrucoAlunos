using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using Truco.Auxiliares;

namespace Truco
{
    class IlusionistaDaMesa : Jogador
    {
        private List<Tuple<Jogador,Carta>> rodada1;
        private List<Tuple<Jogador, Carta>> rodada2;
        private static int pontosRodada = 0;
        private static bool ganhaPrimeira = false;
        private static bool ganhaSegunda = false;
        private int rod = 3;
        
        public IlusionistaDaMesa(string n, Log logar) : base(n, logar)
        {
        }


        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            
            Carta aux;
            if (_mao.Count == 3)
            {
                //Magica(manilha);
                ordenar(manilha);
            }
            ganheiPrimeira(cartasRodada);
            ganheiSegunda(cartasRodada);

            #region UltimaCarta
           if (_mao.Count() == 1)
            {
                if (cartasRodada.Count > 2 && _mao[0].valor(manilha) > cartasRodada.Max(x => x.valor(manilha)))
                {
                    pedirTruco(this, trucar());
                    return jogaMenor();
                }

                if (ganhaPrimeira)
                {
                    if (retornaMaiorCartaIlusionista(rodada1, manilha).valor(manilha) < retornaMaiorCartaAdversario(rodada2, manilha).valor(manilha))
                    {
                        pedirTruco(this, trucar());
                        return jogaMenor();
                    }                    
                }
                else if (ganhaSegunda)
                {
                    if (retornaMaiorCartaIlusionista(rodada2, manilha).valor(manilha) < retornaMaiorCartaAdversario(rodada1, manilha).valor(manilha))
                    {
                        pedirTruco(this, trucar());
                        return jogaMenor();
                    }
                }                

                if (cartasRodada.Count > 3 && cartasRodada.Max(x => x.valor(manilha)) < 11)
                {
                    pedirTruco(this, trucar());
                    return jogaMenor();
                } 
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
                if(_mao.Count == 3)
                {
                    if (cartasRodada[0].valor(manilha) == 14)
                    {
                        pedirTruco(this, trucar());
                        return jogaMenor();
                    }
                }                

                if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) < 7)
                {
                    log.logar("Faz ai parceiro.", TipoLog.logJogador);
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
            rod++;
            Tuple<Jogador, Carta> t = new Tuple<Jogador, Carta>(jogador,carta);
            if (rod/4==1)
            {
                rodada1.Add(t);
                return;
            }
            if (rod/4==2)
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
            if (_mao.Count() == 3)
            {
                if (_mao.Where(x => x.valor(manilha) >= 10).Count() >= 2)
                {
                    return aceitarComZap(manilha, valor);
                } 
            }
            //segunda rodada
            if (_mao.Count == 2)
            {
                if (ganhaPrimeira && _mao.Where(x => x.valor(manilha) >= 9).Count() >= 1)
                    return aceitarComZap(manilha, valor); 
            }
            //terceira rodada
            if (_mao.Count() == 1)
            {
                if (ganhaPrimeira)
                    return Escolha.aceitar;

                if (ganhaPrimeira && _mao.Where(x => x.valor(manilha) >= 10).Count() >= 1)
                    return aumentar(valor);

                if (ganhaSegunda && _mao.Where(x => x.valor(manilha) >= 10).Count() >= 1)
                    return aceitarComZap(manilha, valor);
            }
            log.logar("MUITA CARTA NA MAO DE TONTO, É SÓ UM PONTO", TipoLog.logJogador);
            return Escolha.correr;
        }

        private CardGame.Truco trucar()
        {
            return (CardGame.Truco)pontosRodada;
        }

        private void trucarNaPrimeira(Carta manilha)
        {
            if ( Equipe.BuscaID(this.IDEquipe).PontosEquipe>=12 || Equipe.BuscaID(this.IDEquipe).Adversario.PontosEquipe>=12)
            {
                return;
            }
            if (_mao.Where(x => x.valor(manilha) >= 11).Count() >= 2 && _mao.Count() == 3)
            {
                log.logar(frasesEfeito(), TipoLog.logJogador);
                pedirTruco(this, trucar());
                pontosRodada++;
            }
        }

        public override void NovaMao()
        {
            base.NovaMao();
            rodada1 = new List<Tuple<Jogador, Carta>>();
            rodada2 = new List<Tuple<Jogador, Carta>>();
            ganhaPrimeira = false;
            ganhaSegunda = false;
            pontosRodada = 0;
            rod = 3;
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
            log.logar(frasesEfeito(), TipoLog.logJogador);
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
        { 
        
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

        private void Magica(Carta manilha)
        {
            Carta C = new Carta(Naipes.paus,manilha.Valor+1);
            _mao[0] = C;
            C = new Carta(Naipes.copas, manilha.Valor + 1);
            _mao[1] = C;
            C = new Carta(Naipes.espadas, manilha.Valor + 1);
            _mao[2] = C;
        }
    }
}
