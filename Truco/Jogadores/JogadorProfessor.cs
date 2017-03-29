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
            cartasNaoUasadas = geraBaralho();
        }

        private List<Carta> cartasUsadas;
        private Truco? trucoAtual;
        private List<Carta> cartasNaoUasadas;
        private int pontosRodada;

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            if (_mao.Count == 3)
            {
                foreach (var item in _mao)
                {
                    cartasNaoUasadas.Remove(item);
                }
            }
        }

        public override void NovaMao()
        {
            base.NovaMao();
            cartasUsadas = new List<Carta>();
            trucoAtual = null;
            cartasNaoUasadas = geraBaralho();
        }

        private static List<Carta> geraBaralho()
        {
            List<Carta> retorno = new List<Carta>();
            for (int i = 1; i < 14; i++)
            {
                if (i != 8 && i != 9 && i != 10)
                {
                    retorno.Add(new Carta(Naipes.copas, i));
                    retorno.Add(new Carta(Naipes.espadas, i));
                    retorno.Add(new Carta(Naipes.ouros, i));
                    retorno.Add(new Carta(Naipes.paus, i));
                }
            }
            return retorno;
        }

        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {
            cartasNaoUasadas.Remove(carta);
        }

        private int probabilidadeVitoria(Carta manilha)
        {
            if (pontosRodada == 1)
            cartasNaoUasadas.Remove(manilha);
            double cartasMelhoresDisponivies = cartasNaoUasadas.Where(x => x.valor(manilha) >= (_mao.ma));
        }
    }
}
