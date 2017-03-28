using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;


namespace Truco
{

   

    class JogadorEquipeAlfa : Jogador
    {

        public JogadorEquipeAlfa(string n) : base(n) { }

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {



            // encontra maior da mesa
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            Carta maiorMesa = cartasRodada.LastOrDefault();
            for (int i = 0; i < cartasRodada.Count - 1; i++)
            {
                if (TrucoAuxiliar.comparar(cartasRodada[i], maiorMesa, manilha) > 0)
                {
                    maiorMesa = cartasRodada[i];
                }
            }

            //descarta
            Carta carta = _mao.LastOrDefault();

            if (cartasRodada.LastOrDefault() == null)
            {
                _mao.RemoveAt(2);
                return carta;
            }
            else if (cartasRodada.Count == 1)
            {
                for (int i = 0; i < _mao.Count; i++)
                {
                    
                    if (TrucoAuxiliar.comparar(_mao[i], cartasRodada[0], manilha) > 0)
                    {
                        carta = _mao[i];
                        _mao.RemoveAt(i);
                        return carta;

                    }
                    
                }
                carta = _mao[0];
                _mao.RemoveAt(0);
                return carta;
            }
            else if (cartasRodada.Count == 2)
            {
                carta = _mao[0];
                _mao.RemoveAt(0);
                return carta;
            } else
            {
                for (int i = 0; i < _mao.Count; i++)
                {

                    if (TrucoAuxiliar.comparar(_mao[i], cartasRodada[0], manilha) > 0)
                    {
                         carta = _mao[i];
                        _mao.RemoveAt(i);
                        return carta;

                    }
                   
                }
                carta = _mao[0];
                _mao.RemoveAt(0);
                return carta;
            }
        }

    }
}
