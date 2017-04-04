using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;
using Truco.Enumeradores;

namespace CardGame
{
    class JurandirOJogador : Jogador
    {

        private List<ICartas> ICartassUsadas = new List<ICartas>();
        private bool estaTrucado = false;
        private static bool ganhoPrimeira = false;


        public JurandirOJogador(string sobrenome, Log logar) : base("Jurandir o "+sobrenome, logar)
        {

        }

        public override void NovaMao()
        {
            base.NovaMao();
            ICartassUsadas = new List<ICartas>();
        }


        public override ICartas Jogar(List<ICartas> ICartassRodada, ICartas manilha)
        {

            // encontra maior da mesa
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }

            RegraTrucar(manilha);
            ICartas ICartas;

            switch (_mao.Count)
            {

                #region case 3
                case 3:
                    //ICartas maiorMesa = ICartassRodada.LastOrDefault();

                    if (ICartassRodada.Count == 0)
                    {
                        if (TrucoAuxiliar.gerarValorICartas(_mao[1], manilha) > 7)
                        {
                            ICartas = _mao[1];
                            _mao.RemoveAt(1);
                            return ICartas;
                        }
                        else
                        {
                            ICartas = _mao[0];
                            _mao.RemoveAt(0);
                            return ICartas;
                        }

                    }

                    if (ICartassRodada.Count == 1)
                    {
                        if (TrucoAuxiliar.compara(_mao[1], ICartassRodada[0], manilha) > 0)
                        {
                            ICartas = _mao[1];
                            _mao.RemoveAt(1);
                            return ICartas;
                        }
                        else
                        {
                            ICartas = _mao[0];
                            _mao.RemoveAt(0);
                            return ICartas;
                        }
                    }

                    if (ICartassRodada.Count == 2)
                    {
                        if (TrucoAuxiliar.compara(ICartassRodada[0], ICartassRodada[1], manilha) > 0)
                        {
                            ICartas = _mao[0];
                            _mao.RemoveAt(0);
                            return ICartas;
                        }
                        else
                        {
                            for (int i = 0; i < _mao.Count; i++)
                            {
                                ICartas = _mao[i];
                                if (TrucoAuxiliar.comparar(ICartas, ICartassRodada[1], manilha) > 0)
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

                    if (ICartassRodada.Count == 3)
                    {
                        if (TrucoAuxiliar.compara(ICartassRodada[1], ICartassRodada[0], manilha) > 0 && TrucoAuxiliar.compara(ICartassRodada[1], ICartassRodada[2], manilha) > 0)
                        {
                            ICartas = _mao[0];
                            _mao.RemoveAt(0);
                            ganhoPrimeira = true;
                            return ICartas;
                        }
                        else
                        {
                            for (int i = 0; i < _mao.Count; i++)
                            {
                                ICartas = _mao[i];
                                if (TrucoAuxiliar.comparar(ICartas, ICartassRodada[0], manilha) > 0 && TrucoAuxiliar.comparar(ICartas, ICartassRodada[2], manilha) > 0)
                                {
                                    _mao.RemoveAt(i);
                                    ganhoPrimeira = true;
                                    return ICartas;
                                }
                            }
                            ICartas = _mao[0];
                            _mao.RemoveAt(0);
                            return ICartas;
                        }



                    }

                    return null;

                #endregion

                #region case 2
                case 2:


                    //ICartas maiorMesa = ICartassRodada.LastOrDefault();

                    if (ICartassRodada.Count == 0)
                    {
                        ganhoPrimeira = true;
                        ICartas = _mao[0];
                        _mao.RemoveAt(0);
                        return ICartas;


                    }

                    if (ICartassRodada.Count == 1)
                    {

                        ICartas = _mao[0];
                        _mao.RemoveAt(0);
                        return ICartas;
                    }
                    if (ICartassRodada.Count == 2)
                    {
                        ICartas = _mao[1];
                        _mao.RemoveAt(1);
                        return ICartas;

                    }
                    if (ICartassRodada.Count == 3)
                    {
                        if (TrucoAuxiliar.compara(ICartassRodada[1], ICartassRodada[0], manilha) > 0 && TrucoAuxiliar.compara(ICartassRodada[1], ICartassRodada[2], manilha) > 0)
                        {
                            ICartas = _mao[0];
                            _mao.RemoveAt(0);
                            return ICartas;
                        }
                        else
                        {
                            for (int i = 0; i < _mao.Count; i++)
                            {
                                ICartas = _mao[i];
                                if (TrucoAuxiliar.comparar(ICartas, ICartassRodada[0], manilha) > 0 && TrucoAuxiliar.comparar(ICartas, ICartassRodada[2], manilha) > 0)
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

                    return null;
                #endregion

                #region case 1
                case 1:
                    ICartas = _mao[0];
                    _mao.RemoveAt(0);
                    return ICartas;
                default: return null;
                    #endregion

            }
        }

        public override void novaICartas(ICartas ICartas, Jogador jogador, ICartas manilha)
        {

            ICartassUsadas.Add(ICartas);
            if (ganhoPrimeira 
                && !estaTrucado
                && Equipe.BuscaID(this.IDEquipe).PontosEquipe < 12
                && Equipe.BuscaID(this.IDEquipe).Adversario.PontosEquipe < 12)
            {
                if (jogador.IDEquipe != this.IDEquipe)
                {
                    if ((_mao.Count < 3 && _mao.Count > 0) 
                        && ((ICartas.valor(manilha) < _mao[0].valor(manilha)) || Equipe.BuscaID(this.IDEquipe).PontosEquipe < 6))
                    {
                        base.trucar(this, EnumTruco.truco);
                    }
                }
            }
        }

        public override Escolha trucado(Jogador trucante, EnumTruco valor, ICartas manilha)
        {
            int ptsMinhaEqp = Equipe.BuscaID(this.IDEquipe).PontosEquipe;
            int ptsEqpAdv = Equipe.BuscaID(trucante.IDEquipe).PontosEquipe;
            int x = ManilhasNaMao(manilha);

            if ((ptsEqpAdv > ptsMinhaEqp && ptsEqpAdv + valorJogoTruco(valor) < 15) && ptsMinhaEqp - ptsEqpAdv > valorJogoTruco(valor))
            {
                if (ICartassUsadas.Count < 4 && x > 0)
                {
                    return Escolha.aceitar;
                }

                if (ICartassUsadas.Count < 4 && _mao[0].valor(manilha) > 8)
                {
                    return Escolha.aceitar;
                }

                if (ganhoPrimeira && x > 0)
                {
                    return Escolha.aumentar;
                }

                if (ganhoPrimeira && (ICartassUsadas.Count > 3 || ICartassUsadas.Count < 8) && (_mao[0].valor(manilha) > 8 || _mao[1].valor(manilha) > 8))
                {
                    return Escolha.aceitar;
                }

                if ((ICartassUsadas.Count > 3 || ICartassUsadas.Count < 8) && (_mao[0].valor(manilha) > 10))
                {
                    return Escolha.aceitar;
                }


                if (ganhoPrimeira && (_mao[0].valor(manilha) > 7))
                {
                    return Escolha.aceitar;
                }
            }
            return Escolha.correr;
            
            //if (x >= 2)
            //    return Escolha.aumentar;
            //if (x == 1)
            //    return Escolha.aceitar;
            //if (ptsEqpAdv > 9 && ptsMinhaEqp < 5)
            //    return Escolha.aumentar;
            //if (_mao.Count == 3)
            //{
            //    if (_mao[0].valor(manilha) > 7)
            //        return Escolha.aceitar;
            //}
            //if (_mao.Count == 2)
            //{
            //    if (_mao[0].valor(manilha) > 7)
            //        return Escolha.aceitar;
            //}

            //if (_mao.Count == 0 && ICartassUsadas.Last().valor(manilha) > 8)
            //    return Escolha.aceitar;

            //if (_mao.Count == 1 &&_mao[0].valor(manilha) <= 3)
            //    return Escolha.correr;
            //else
            //    return Escolha.aceitar;

        }

        private int valorJogoTruco(EnumTruco valor)
        {

            if (valor == EnumTruco.truco) return 3;
            if (valor == EnumTruco.seis) return 6;
            if (valor == EnumTruco.nove) return 9;
            if (valor == EnumTruco.doze) return 12;
            if (valor == EnumTruco.jogo) return 15;
            else return 0;
        }

        private void RegraTrucar(ICartas manilha)
        {
            if (Equipe.BuscaID(this.IDEquipe).PontosEquipe < 12 && Equipe.BuscaID(this.IDEquipe).Adversario.PontosEquipe < 12)
            {
                if (!estaTrucado)
                {
                    if (_mao.Count == 3)
                    {
                        Random dado = new Random();
                        int x = dado.Next(0, 6);
                        if (x == 1 || x == 6) base.trucar(this, EnumTruco.truco);
                    }
                    else if (_mao.Count == 2)
                    {
                        if (ICartassUsadas.Count == 4 || ICartassUsadas.Count == 6)
                        {
                            if (_mao[1].valor(manilha) > 8) base.trucar(this, EnumTruco.truco);
                        }
                        else
                        {
                            if (_mao[0].valor(manilha) >= 10 && _mao[1].valor(manilha) >= 10) base.trucar(this, EnumTruco.truco);
                        }
                    }
                    else if (_mao.Count == 1)
                    {
                        if (_mao[0].valor(manilha) > 10) base.trucar(this, EnumTruco.truco);
                    }
                }
            }
        }

        private int ManilhasNaMao(ICartas manilha)
        {
            int cont = 0;
            foreach (var x in _mao)
            {
                cont = (x.valor(manilha) > 9) ? cont : cont;
            }
            return cont;
        }
    }
}

