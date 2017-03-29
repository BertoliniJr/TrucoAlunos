using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class JurandirOJogador : Jogador
    {

        private List<Carta> cartasUsadas = new List<Carta>();
        private bool estaTrucado = false;

        public JurandirOJogador(string sobrenome) : base("Jurandir o "+sobrenome)
        {

        }

        public override void NovaMao()
        {
            base.NovaMao();
            cartasUsadas = new List<Carta>();
        }


        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {

            // encontra maior da mesa
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }

            RegraTrucar(manilha);
            Carta carta;

            switch (_mao.Count)
            {

                #region case 3
                case 3:
                    //Carta maiorMesa = cartasRodada.LastOrDefault();

                    if (cartasRodada.Count == 0)
                    {
                        if (TrucoAuxiliar.gerarValorCarta(_mao[1], manilha) > 7)
                        {
                            carta = _mao[1];
                            _mao.RemoveAt(1);
                            return carta;
                        }
                        else
                        {
                            carta = _mao[0];
                            _mao.RemoveAt(0);
                            return carta;
                        }

                    }

                    if (cartasRodada.Count == 1)
                    {
                        if (TrucoAuxiliar.compara(_mao[1], cartasRodada[0], manilha) > 0)
                        {
                            carta = _mao[1];
                            _mao.RemoveAt(1);
                            return carta;
                        }
                        else
                        {
                            carta = _mao[0];
                            _mao.RemoveAt(0);
                            return carta;
                        }
                    }

                    if (cartasRodada.Count == 2)
                    {
                        if (TrucoAuxiliar.compara(cartasRodada[0], cartasRodada[1], manilha) > 0)
                        {
                            carta = _mao[0];
                            _mao.RemoveAt(0);
                            return carta;
                        }
                        else
                        {
                            for (int i = 0; i < _mao.Count; i++)
                            {
                                carta = _mao[i];
                                if (TrucoAuxiliar.comparar(carta, cartasRodada[1], manilha) > 0)
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

                    if (cartasRodada.Count == 3)
                    {
                        if (TrucoAuxiliar.compara(cartasRodada[1], cartasRodada[0], manilha) > 0 && TrucoAuxiliar.compara(cartasRodada[1], cartasRodada[2], manilha) > 0)
                        {
                            carta = _mao[0];
                            _mao.RemoveAt(0);
                            return carta;
                        }
                        else
                        {
                            for (int i = 0; i < _mao.Count; i++)
                            {
                                carta = _mao[i];
                                if (TrucoAuxiliar.comparar(carta, cartasRodada[0], manilha) > 0 && TrucoAuxiliar.comparar(carta, cartasRodada[2], manilha) > 0)
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

                    return null;

                #endregion

                #region case 2
                case 2:


                    //Carta maiorMesa = cartasRodada.LastOrDefault();

                    if (cartasRodada.Count == 0)
                    {

                        carta = _mao[0];
                        _mao.RemoveAt(0);
                        return carta;


                    }

                    if (cartasRodada.Count == 1)
                    {

                        carta = _mao[0];
                        _mao.RemoveAt(0);
                        return carta;
                    }
                    if (cartasRodada.Count == 2)
                    {
                        carta = _mao[1];
                        _mao.RemoveAt(1);
                        return carta;

                    }
                    if (cartasRodada.Count == 3)
                    {
                        if (TrucoAuxiliar.compara(cartasRodada[1], cartasRodada[0], manilha) > 0 && TrucoAuxiliar.compara(cartasRodada[1], cartasRodada[2], manilha) > 0)
                        {
                            carta = _mao[0];
                            _mao.RemoveAt(0);
                            return carta;
                        }
                        else
                        {
                            for (int i = 0; i < _mao.Count; i++)
                            {
                                carta = _mao[i];
                                if (TrucoAuxiliar.comparar(carta, cartasRodada[0], manilha) > 0 && TrucoAuxiliar.comparar(carta, cartasRodada[2], manilha) > 0)
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

                    return null;
                #endregion

                #region case 1
                case 1:
                    carta = _mao[0];
                    _mao.RemoveAt(0);
                    return carta;
                default: return null;
                    #endregion

            }
        }

        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {

            cartasUsadas.Add(carta);
            if (!estaTrucado
                && Equipe.BuscaID(this.IDEquipe).PontosEquipe < 12
                || Equipe.BuscaID(this.IDEquipe).Adversario.PontosEquipe < 12)
            {
                if (jogador.IDEquipe != this.IDEquipe)
                {
                    if ((_mao.Count < 3 && _mao.Count > 0) && (carta.valor(manilha) < _mao[0].valor(manilha)) || Equipe.BuscaID(this.IDEquipe).PontosEquipe < 6)
                    {
                        base.trucar(this, Truco.truco);
                    }
                }
            }
        }

        public override Escolha trucado(Jogador trucante, Truco valor, Carta manilha)
        {
            int ptsMinhaEqp = Equipe.BuscaID(this.IDEquipe).PontosEquipe;
            int ptsEqpAdv = Equipe.BuscaID(trucante.IDEquipe).PontosEquipe;

            if (ptsMinhaEqp - ptsEqpAdv > valorJogoTruco(valor))
                return Escolha.aceitar;
            if ((ptsEqpAdv > ptsMinhaEqp && ptsEqpAdv + valorJogoTruco(valor) < 15))
                return Escolha.aceitar;

            int x = ManilhasNaMao(manilha);
            if (x >= 2)
                return Escolha.aumentar;
            if (ptsEqpAdv > 9 && ptsMinhaEqp < 5)
                return Escolha.aumentar;


            if (_mao[0].valor(manilha) < 8)
                return Escolha.correr;
            else
                return Escolha.aceitar;

        }

        private int valorJogoTruco(Truco valor)
        {

            if (valor == Truco.truco) return 3;
            if (valor == Truco.seis) return 6;
            if (valor == Truco.nove) return 9;
            if (valor == Truco.doze) return 12;
            if (valor == Truco.jogo) return 15;
            else return 0;
        }

        private void RegraTrucar(Carta manilha)
        {
            if (Equipe.BuscaID(this.IDEquipe).PontosEquipe < 12 || Equipe.BuscaID(this.IDEquipe).Adversario.PontosEquipe < 12)
            {
                if (!estaTrucado)
                {
                    if (_mao.Count == 3)
                    {
                        Random dado = new Random();
                        int x = dado.Next(0, 6);
                        if (x == 1 || x == 6) base.trucar(this, Truco.truco);
                    }
                    else if (_mao.Count == 2)
                    {
                        if (cartasUsadas.Count == 4 || cartasUsadas.Count == 6)
                        {
                            if (_mao[1].valor(manilha) > 8) base.trucar(this, Truco.truco);
                        }
                        else
                        {
                            if (_mao[0].valor(manilha) >= 10 && _mao[1].valor(manilha) >= 10) base.trucar(this, Truco.truco);
                        }
                    }
                    else if (_mao.Count == 1)
                    {
                        if (_mao[0].valor(manilha) > 10) base.trucar(this, Truco.truco);
                    }
                }
            }
        }

        private int ManilhasNaMao(Carta manilha)
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

