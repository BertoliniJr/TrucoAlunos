﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class JurandirOJogador : Jogador
    {

        private List<Carta> cartasUsadas = new List<Carta>();

        public JurandirOJogador() : base("Jurandir o Pika das Galaxias")
        {

        }

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {

            // encontra maior da mesa
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            Carta carta;

            switch (_mao.Count)
            {
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

                case 1:
                    carta = _mao[0];
                    _mao.RemoveAt(0);
                    return carta;
                default: return null;


            }
        }

        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {
            cartasUsadas.Add(carta);

            if(_mao.Count == 3)
            {
                int cartasBoas = 0;
                foreach(var x in _mao)
                {
                    cartasBoas = x.Valor >=10 ? cartasBoas + 1 : cartasBoas;
                }

                if(cartasBoas > 1)
                {

                }

            }
            if (_mao.Count == 2)
            {

            }

            if (_mao.Count == 1)
            {

            }

            //    if (jogador.IDEquipe != this.IDEquipe)
            //{
            //    if (_mao.Count != 2)
            //    {
            //        if (TrucoAuxiliar.compara(_mao[0], carta, manilha) > 0)
            //            base.trucar(this, Truco.truco);
            //    }
            //}
        }

        public override Escolha trucado(Jogador trucante, Truco valor)
        {
            if (trucante.IDEquipe != this.IDEquipe && Equipe.BuscaID(this.IDEquipe).PontosEquipe < valorJogoTruco(valor))
                return Escolha.aceitar;
            else if(TrucoAuxiliar.comparar(_mao.LastOrDefault(), cartasUsadas.LastOrDefault(), manilha) > 0)
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
    }
}
