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

        public int Teste(Jogador Oponente1, Jogador Oponente2)
        {
            int count = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = Oponente1;
                Jogador jogador2 = new JurandirOJogador();
                Jogador jogador3 = Oponente2;
                Jogador jogador4 = new JurandirOJogador();
                

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
