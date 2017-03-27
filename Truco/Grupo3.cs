using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Grupo3:Jogador
    {
        public Grupo3(string n) : base(n) { }
        public override Carta Jogar(List<Carta> cartasMesa, Carta manilha)
        {
            return null;
        }
    }
}
