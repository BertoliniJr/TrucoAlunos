using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco;

namespace CardGame
{
    class Juvenal : Jogador
    {
        private List<Carta> cartasJogadas;

        public Juvenal(string n) : base(n) { }
        public override Carta Jogar(List<Carta> cartasMesa, Carta manilha)
        {
            //ordenando
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            Carta carta = _mao[0];
            //primeiro a jogar
            if (cartasMesa.Count == 0)
            {
                carta = primeiroJogar(cartasMesa, manilha);
            }//segundo a jogar
            else if (cartasMesa.Count == 1)
            {
                carta = segundoJogar(cartasMesa, manilha);
            } // terceiro a jogar
            else if (cartasMesa.Count == 2)
            {
                carta = terceiroJogar(cartasMesa, manilha);
            }// quarto a jogar
            else if (cartasMesa.Count == 3)
            {
                carta = quartoJogar(cartasMesa, manilha);
            }

            return carta;
        }
        

        public Carta primeiroJogar(List<Carta> cartasMesa, Carta manilha)
        {
            Carta carta = _mao.Last();
            _mao.Remove(_mao.Last());
            return carta;
        }
        public Carta segundoJogar(List<Carta> cartasMesa, Carta manilha)
        {
            Carta carta = _mao[0];
            for (int i = 0; i < _mao.Count; i++)
            {
                if (TrucoAuxiliar.compara(_mao[i], cartasMesa[0], manilha) > 0)
                {
                    carta = _mao[i];
                    _mao.RemoveAt(i);
                    break;
                }
            }

            return carta;
        }
        public Carta terceiroJogar(List<Carta> cartasMesa, Carta manilha)
        {
            Carta carta = _mao[0];
            if (TrucoAuxiliar.gerarValorCarta(cartasMesa[0], manilha) > TrucoAuxiliar.gerarValorCarta(cartasMesa[1], manilha))
            {
                carta = _mao[0];
                _mao.RemoveAt(0);
            }
            else
            {
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.compara(_mao[i], cartasMesa[1], manilha) > 0)
                    {
                        carta = _mao[i];
                        _mao.RemoveAt(i);
                        break;
                    }
                }
            }
            return carta;
        }
        public Carta quartoJogar(List<Carta> cartasMesa, Carta manilha)
        {
            Carta carta = _mao[0];
            if (TrucoAuxiliar.gerarValorCarta(cartasMesa[1], manilha) > TrucoAuxiliar.gerarValorCarta(cartasMesa[0], manilha) && TrucoAuxiliar.gerarValorCarta(cartasMesa[1], manilha) > TrucoAuxiliar.gerarValorCarta(cartasMesa[2], manilha))
            {
                carta = _mao[0];
                _mao.RemoveAt(0);
            }
            else
            {
                Carta maior = null;
                if (TrucoAuxiliar.gerarValorCarta(cartasMesa[0], manilha) > TrucoAuxiliar.gerarValorCarta(cartasMesa[2], manilha))
                {
                    maior = cartasMesa[0];
                }
                else
                {
                    maior = cartasMesa[2];
                }
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.compara(_mao[i], maior, manilha) > 0)
                    {
                        carta = _mao[i];
                        _mao.RemoveAt(i);
                        break;
                    }
                }
            }
            return carta;
        }
        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {

            cartasJogadas.Add(carta);
            if ( _mao.Count <= 2 )
            {
                 
            }
            base.novaCarta(carta, jogador, manilha);
        }
        public override Escolha trucado(Jogador trucante, Truco valor)
        {
            return base.trucado(trucante, valor);
        }
    }
}
