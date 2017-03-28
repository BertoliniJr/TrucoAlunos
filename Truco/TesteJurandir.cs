using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;

namespace Truco
{
    class TesteJurandir
    {

        public static int Teste1(Jogador Oponente)
        {
            int count = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JurandirOJogador();
                Jogador jogador2 = new IlusionistaDaMesa("p1");
                Jogador jogador3 = new JurandirOJogador();
                Jogador jogador4 = new IlusionistaDaMesa("p1");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
                mesaDeTruco.Jogar();

                if(equipe1.PontosEquipe == 15)
                {
                    count++;
                }

            }

            return count;
        }




    }
}
