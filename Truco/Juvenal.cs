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
        public Juvenal(string n) : base(n) { }
        public override Carta Jogar(List<Carta> cartasMesa, Carta manilha)
        {
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            Carta carta = _mao[0];
            if (cartasMesa.Count == 0)
            {
                carta = _mao.Last();
                _mao.Remove(_mao.Last());
            }
            else if (cartasMesa.Count == 1)
            {
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.compara(_mao[i], cartasMesa[0], manilha) > 0)
                    {
                        carta = _mao[i];
                        _mao.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (cartasMesa.Count == 2)
            {
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
            }
            else if (cartasMesa.Count == 3)
            {
                if (TrucoAuxiliar.gerarValorCarta(cartasMesa[1], manilha) > TrucoAuxiliar.gerarValorCarta(cartasMesa[0], manilha) && TrucoAuxiliar.gerarValorCarta(cartasMesa[1], manilha) > TrucoAuxiliar.gerarValorCarta(cartasMesa[2], manilha))
                {
                    carta = _mao[0];
                    _mao.RemoveAt(0);
                }
                else
                {
                    Carta maior = null;
                    if (TrucoAuxiliar.gerarValorCarta(cartasMesa[0],manilha) > TrucoAuxiliar.gerarValorCarta(cartasMesa[2],manilha))
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
            }

            return carta;
        }
    }
}
