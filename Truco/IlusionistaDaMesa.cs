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
        public IlusionistaDaMesa(string n) : base(n)
        {
        }

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            return null;
        }
        public void Correr()
        {

        }
    }
}
