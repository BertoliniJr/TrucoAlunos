using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using Truco.Auxiliares;
using Truco.Enumeradores;

namespace Truco
{
    class IlusionistaDaMesa : Jogador
    {
        private List<Tuple<Jogador,ICartas>> rodada1;
        private List<Tuple<Jogador, ICartas>> rodada2;
        private static int pontosRodada = 0;
        private static bool ganhaPrimeira = false;
        private static bool ganhaSegunda = false;
        private int rod = 3;
        
        public IlusionistaDaMesa(string n, Log logar) : base(n, logar)
        {
        }


        public override ICartas Jogar(List<ICartas> ICartassRodada, ICartas manilha)
        {
            
            ICartas aux;
            if (_mao.Count == 3)
            {
                //Magica(manilha);
                ordenar(manilha);
            }
            ganheiPrimeira(ICartassRodada);
            ganheiSegunda(ICartassRodada);

            #region UltimaICartas
           if (_mao.Count() == 1)
            {
                if (ICartassRodada.Count > 2 && _mao[0].valor(manilha) > ICartassRodada.Max(x => x.valor(manilha)))
                {
                    pedirTruco(this, trucar());
                    return jogaMenor();
                }

                if (ganhaPrimeira)
                {
                    if (retornaMaiorICartasIlusionista(rodada1, manilha).valor(manilha) < retornaMaiorICartasAdversario(rodada2, manilha).valor(manilha))
                    {
                        pedirTruco(this, trucar());
                        return jogaMenor();
                    }                    
                }
                else if (ganhaSegunda)
                {
                    if (retornaMaiorICartasIlusionista(rodada2, manilha).valor(manilha) < retornaMaiorICartasAdversario(rodada1, manilha).valor(manilha))
                    {
                        pedirTruco(this, trucar());
                        return jogaMenor();
                    }
                }                

                if (ICartassRodada.Count > 3 && ICartassRodada.Max(x => x.valor(manilha)) < 11)
                {
                    pedirTruco(this, trucar());
                    return jogaMenor();
                } 
            }
            #endregion

            #region PrimeiroAjogar
            if (ICartassRodada.LastOrDefault() == null)
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
            if (ICartassRodada.Count == 1)
            {
                //segundo da primeira rodada
                trucarNaPrimeira(manilha);
                if(_mao.Count == 3)
                {
                    if (ICartassRodada[0].valor(manilha) == 14)
                    {
                        pedirTruco(this, trucar());
                        return jogaMenor();
                    }
                }                

                if (ICartassRodada.Max(x => TrucoAuxiliar.gerarValorICartas(x, manilha)) < 7)
                {
                    log.logar("Faz ai parceiro.", TipoLog.logJogador);
                    return jogaMenor();
                }
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (ICartassRodada.Max(x => TrucoAuxiliar.gerarValorICartas(x, manilha)) < TrucoAuxiliar.gerarValorICartas(_mao[i], manilha))
                    {
                        aux = _mao[i];
                        _mao.RemoveAt(i);
                        return aux;
                    }
                }
            }
            #endregion

            #region TerceiroAjogar
            if (ICartassRodada.Count == 2)
            {
                trucarNaPrimeira(manilha);

                if (ICartassRodada.Max(x => TrucoAuxiliar.gerarValorICartas(x, manilha)) > TrucoAuxiliar.gerarValorICartas(_mao.Last(), manilha))
                {
                    return jogaMenor();
                }
                aux = _mao[0];
                //aux = (ICartas)_mao.Where(x=>x.Valor==_mao.Max(y=>y.Valor)&&x.Valor<11);
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.gerarValorICartas(_mao[i], manilha) < 11)
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
                if (ICartassRodada.Max(x => TrucoAuxiliar.gerarValorICartas(x, manilha)) < TrucoAuxiliar.gerarValorICartas(_mao[i], manilha) && TrucoAuxiliar.gerarValorICartas(ICartassRodada[ICartassRodada.Count - 2], manilha) != ICartassRodada.Max(x => TrucoAuxiliar.gerarValorICartas(x, manilha)))
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
        public override void novaICartas(ICartas ICartas, Jogador jogador, ICartas manilha)
        {
            rod++;
            Tuple<Jogador, ICartas> t = new Tuple<Jogador, ICartas>(jogador,ICartas);
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

        public override Escolha trucado(Jogador trucante, EnumTruco valor, ICartas manilha)
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
            log.logar("MUITA ICartas NA MAO DE TONTO, É SÓ UM PONTO", TipoLog.logJogador);
            return Escolha.correr;
        }

        private EnumTruco trucar()
        {
            return (EnumTruco)pontosRodada;
        }

        private void trucarNaPrimeira(ICartas manilha)
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
            rodada1 = new List<Tuple<Jogador, ICartas>>();
            rodada2 = new List<Tuple<Jogador, ICartas>>();
            ganhaPrimeira = false;
            ganhaSegunda = false;
            pontosRodada = 0;
            rod = 3;
        }

        private void ganheiPrimeira(List<ICartas> ICartassRodada)
        {
            if (_mao.Count==2 && (ICartassRodada.Count == 0 || ICartassRodada.Count == 2))
            {
                ganhaPrimeira = true;
            }
        }

        private void ganheiSegunda(List<ICartas> ICartassRodada)
        {
            if (_mao.Count == 1 && (ICartassRodada.Count == 0 || ICartassRodada.Count == 2))
            {
                ganhaSegunda = true;
            }
        }

        private ICartas jogaMenor()
        {
            ICartas aux;
            aux = _mao[0];
            _mao.RemoveAt(0);
            return aux;
        }

        private Escolha aceitar(EnumTruco valor)
        {
            pontosRodada = (int)valor;
            return Escolha.aceitar;
        }

        private Escolha aumentar(EnumTruco valor)
        {
            pontosRodada = (int)valor;
            return Escolha.aumentar;
        }

        private Escolha aceitarComZap(ICartas manilha, EnumTruco valor)
        {
            if (_mao.Last().valor(manilha) == 14)
            {
                return aumentar(valor);
            }
            return aceitar(valor);
        }

        private void pedirTruco(Jogador jogador, EnumTruco pedido)
        {
            if (Equipe.BuscaID(IDEquipe).Adversario.PontosEquipe>=12||Equipe.BuscaID(IDEquipe).PontosEquipe>=12)
            {
                return;
            }
            log.logar(frasesEfeito(), TipoLog.logJogador);
            base.trucar(jogador, pedido);
        }

        private ICartas retornaMaiorICartasIlusionista(List<Tuple<Jogador, ICartas>> rodada, ICartas manilha)
        {
            var ICartassIlusionista = rodada.Where(x => x.Item1.IDEquipe == this.IDEquipe).ToList();
            
            ICartas c = ICartassIlusionista[0].Item2;

            foreach (var tupla in ICartassIlusionista)
            {
                if(TrucoAuxiliar.gerarValorICartas(tupla.Item2, manilha) > TrucoAuxiliar.gerarValorICartas(c, manilha))
                {
                    c = tupla.Item2;
                }
            }
            return c;
        }

        private ICartas retornaMaiorICartasAdversario(List<Tuple<Jogador, ICartas>> rodada, ICartas manilha)
        {
            var ICartassAdversario = rodada.Where(x => x.Item1.IDEquipe == this.IDEquipe).ToList();

            ICartas c = ICartassAdversario[0].Item2;

            foreach (var tupla in ICartassAdversario)
            {
                if (TrucoAuxiliar.gerarValorICartas(tupla.Item2, manilha) > TrucoAuxiliar.gerarValorICartas(c, manilha))
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

        private void Magica(ICartas manilha)
        {
            ICartas C = new ICartas(Naipes.paus,manilha.Valor+1);
            _mao[0] = C;
            C = new ICartas(Naipes.copas, manilha.Valor + 1);
            _mao[1] = C;
            C = new ICartas(Naipes.espadas, manilha.Valor + 1);
            _mao[2] = C;
        }
    }
}
