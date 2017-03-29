using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class JogadorProfessor : Jogador
    {
        public JogadorProfessor(string n) : base(n)
        {
            nome = $"Professor {n}";
        }

        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {

        }
    }
}
