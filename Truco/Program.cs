using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;

namespace Truco
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Jogador jogador1 = new Jogador("Jogador 1");
              Jogador jogador2 = new IlusionistaDaMesa("Jogador 2");
              Jogador jogador3 = new Jogador("Jogador 3");
              Jogador jogador4 = new IlusionistaDaMesa("Jogador 4");

              Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
              Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

              Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
              mesaDeTruco.Jogar();
              Console.ReadLine */

            //TesteAlffa teste = new TesteAlffa();
            //teste.BrigaIlusionista();

            Testes.TesteProfessor.testeProfessor();
        }
    }
}
