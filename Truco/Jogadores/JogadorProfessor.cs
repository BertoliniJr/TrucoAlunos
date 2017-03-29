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
            cartasUsadas = new List<Carta>();
            trucoAtual = null;
        }

        private List<Carta> cartasUsadas;
        private Truco? trucoAtual;

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {

        }

        public override void NovaMao()
        {
            base.NovaMao();
            cartasUsadas = new List<Carta>();
            trucoAtual = null;
        }
    }
}
