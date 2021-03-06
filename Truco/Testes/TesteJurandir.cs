﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using Truco.Auxiliares;

namespace Truco
{
    class TesteJurandir
    {
        private Log log;
        public TesteJurandir(Log logar)
        {
            log = logar;
        }
        public int Teste(Jogador Oponente1, Jogador Oponente2)
        {
            int count = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JurandirOJogador("P1", log);
                Jogador jogador2 = Oponente1;
                Jogador jogador3 = new JurandirOJogador("P2", log);
                Jogador jogador4 = Oponente2;

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
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
