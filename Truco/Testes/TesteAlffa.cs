using CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;
using Truco.Enumeradores;

namespace Truco
{
    class TesteAlffa
    {
        private Log log;
        public TesteAlffa(Log logar)
        {
            log = logar;
        }

        public void BrigaJuvenal()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Jogador 1", log);
                Jogador jogador2 = new JogadorEquipeAlfa("Jogador 2", log);
                Jogador jogador3 = new Juvenal("Jogador 3", log);
                Jogador jogador4 = new JogadorEquipeAlfa("Jogador 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe >= 15)
                {
                    contador++;
                }


            }
            log.logar($"O aproveitamento da equipe Alfa contra a equipe Juvenal foi de {contador/10}%", TipoLog.logTeste);
            Console.ReadLine();
            
            
        }


        public void BrigaIlusionista()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new IlusionistaDaMesa("Jogador 1", log);
                Jogador jogador2 = new JogadorEquipeAlfa("Jogador 2", log);
                Jogador jogador3 = new IlusionistaDaMesa("Jogador 3", log);
                Jogador jogador4 = new JogadorEquipeAlfa("Jogador 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe >= 15)
                {
                    contador++;
                }


            }
            log.logar($"O aproveitamento da equipe Alfa contra a equipe IlusionistaDaMesa foi de {contador / 10}%", TipoLog.logTeste);
            Console.ReadLine();


        }

        public void BrigaJurandir()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JurandirOJogador("Jogador 1", log);
                Jogador jogador2 = new JogadorEquipeAlfa("Jogador 2", log);
                Jogador jogador3 = new JurandirOJogador("Jogador 3", log);
                Jogador jogador4 = new JogadorEquipeAlfa("Jogador 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe >= 15)
                {
                    contador++;
                }


            }
            log.logar($"O aproveitamento da equipe Alfa contra a equipe Jurandi foi de {contador / 10}%", TipoLog.logTeste);
            Console.ReadLine();


        }

        public void BrigaPC()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Jogador("Jogador 1", log);
                Jogador jogador2 = new JogadorEquipeAlfa("Jogador 2", log);
                Jogador jogador3 = new Jogador("Jogador 3", log);
                Jogador jogador4 = new JogadorEquipeAlfa("Jogador 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe >= 15)
                {
                    contador++;
                }


            }
            log.logar($"O aproveitamento da equipe Alfa contra a equipe PC foi de {contador / 10}%", TipoLog.logTeste);
            Console.ReadLine();


        }

        public void BrigaProfessor()
        {

            int contador = 0;
            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorProfessor("Jogador 1", log);
                Jogador jogador2 = new JogadorEquipeAlfa("Jogador 2", log);
                Jogador jogador3 = new JogadorProfessor("Jogador 3", log);
                Jogador jogador4 = new JogadorEquipeAlfa("Jogador 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
                mesaDeTruco.Jogar();

                if (equipe2.PontosEquipe >= 15)
                {
                    contador++;
                }


            }
            log.logar($"O aproveitamento da equipe Alfa contra a equipe Professor foi de {contador / 10}%", TipoLog.logTeste);
            Console.ReadLine();


        }

    }
}
