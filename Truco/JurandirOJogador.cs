using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class JurandirOJogador : Jogador
    {
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
            Carta carta = null;

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


                    break;
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

                        carta = _mao[1];
                        _mao.RemoveAt(1);
                        return carta;
                    }

                    if (cartasRodada.Count == 2)
                    {
                        carta = _mao[0];
                        _mao.RemoveAt(0);
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
                    break;
                case 1:
                    carta = _mao[0];
                    _mao.RemoveAt(0);
                    return carta;

                default: return null;

            }
            return null;
        }
    }
}
