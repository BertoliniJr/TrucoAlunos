using CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    class TesteAlffa
    {

        public void BrigaJuvenal()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Jogador 1");
                Jogador jogador2 = new JogadorEquipeAlfa("Jogador 2");
                Jogador jogador3 = new Juvenal("Jogador 3");
                Jogador jogador4 = new JogadorEquipeAlfa("Jogador 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
                mesaDeTruco.Jogar();
                
               if(equipe2.PontosEquipe == 15)
                {
                    contador++;
                }

                
            }
            Console.WriteLine($"O aproveitamento da equipe Alfa contra a equipe Juvenal foi de {contador/10}%");
            Console.ReadLine();
            
            
        }


        public void BrigaIlusionista()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new IlusionistaDaMesa("Jogador 1");
                Jogador jogador2 = new JogadorEquipeAlfa("Jogador 2");
                Jogador jogador3 = new IlusionistaDaMesa("Jogador 3");
                Jogador jogador4 = new JogadorEquipeAlfa("Jogador 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe == 15)
                {
                    contador++;
                }


            }
            Console.WriteLine($"O aproveitamento da equipe Alfa contra a equipe IlusionistaDaMesa foi de {contador / 10}%");
            Console.ReadLine();


        }

        public void BrigaJurandir()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Jogador 1");
                Jogador jogador2 = new JurandirOJogador();
                Jogador jogador3 = new Juvenal("Jogador 3");
                Jogador jogador4 = new JurandirOJogador();

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe == 15)
                {
                    contador++;
                }


            }
            Console.WriteLine($"O aproveitamento da equipe Alfa contra a equipe Jurandi foi de {contador / 10}%");
            Console.ReadLine();


        }

        public void BrigaPC()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Jogador 1");
                Jogador jogador2 = new Jogador("Jogador 2");
                Jogador jogador3 = new Juvenal("Jogador 3");
                Jogador jogador4 = new Jogador("Jogador 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe == 15)
                {
                    contador++;
                }


            }
            Console.WriteLine($"O aproveitamento da equipe Alfa contra a equipe PC foi de {contador / 10}%");
            Console.ReadLine();


        }
    }
}
