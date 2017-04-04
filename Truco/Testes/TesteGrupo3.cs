//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using Truco;
//using Truco.Auxiliares;
//using Truco.Enumeradores;

//namespace CardGame
//{
//    class TesteGrupo3
//    {
//        private Log log;

//        public TesteGrupo3(Log logar)
//        {
//            log = logar;
//        }

//        public void testarProfessor()
//        {



//            int juvenal = 0, professor = 0, empate = 0;


//            Jogador jogador1 = new Juvenal("Juvenal", log);
//            Jogador jogador2 = new JogadorProfessor("", log);
//            Jogador jogador3 = new Juvenal("Juvenal", log);
//            Jogador jogador4 = new JogadorProfessor("", log);

//            log.logar("Juvenal X Professor", TipoLog.logTeste);
//            for (int x = 0; x < 1000; x++)
//            {
//                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
//                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });
//                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
//                mesaDeTruco.Jogar();
//                if (equipe1.PontosEquipe >= 15)
//                {
//                    juvenal++;
//                }
//                else if (equipe2.PontosEquipe >= 15)
//                {
//                    professor++;
//                }
//                else
//                {
//                    empate++;
//                }

//            }
//            log.logar(juvenal + "        " + professor, TipoLog.logTeste);
//            log.logar("Juvenal ganhou {0}% das vezes \n\n", ((double)juvenal / 1000D) * 100D, TipoLog.logTeste);
//            log.logar("        \n   ", TipoLog.logTeste);
//            log.logar("A equipe 1 ganhou {0} vezes, e a equipe 2 ganhour {1}, ficou {2}", juvenal, professor, empate, TipoLog.logTeste);
//        }

//        public void testarIlusionista()
//        {



//            int juvenal = 0, ilusionista = 0, empate = 0;


//            Jogador jogador1 = new Juvenal("Juvenal", log);
//            Jogador jogador2 = new IlusionistaDaMesa("Ilusionista", log);
//            Jogador jogador3 = new Juvenal("Juvenal", log);
//            Jogador jogador4 = new IlusionistaDaMesa("Ilusionista", log);

//            log.logar("Juvenal X Ilusionista", TipoLog.logTeste);

//            for (int x = 0; x < 1000; x++)

//            {

//                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
//                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });




//                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);


//                mesaDeTruco.Jogar();




//                if (equipe1.PontosEquipe >= 15)
//                {
//                    juvenal++;
//                }
//                else if (equipe2.PontosEquipe >= 15)
//                {
//                    ilusionista++;
//                }
//                else
//                {
//                    empate++;
//                }

//            }
//            log.logar(juvenal + "            " + ilusionista, TipoLog.logTeste);
//            log.logar("Juvenal ganhou {0}% das vezes \n\n", ((double)juvenal / 1000D) * 100D, TipoLog.logTeste);
//            log.logar("          \n ", TipoLog.logTeste);
//            log.logar("A equipe 1 ganhou {0} vezes, e a equipe 2 ganhour {1}, ficou {2}", juvenal, ilusionista, empate, TipoLog.logTeste);

//        }

//        public void testarJurandir()
//        {



//            int juvenal = 0, Jurandir = 0, empate = 0;


//            Jogador jogador1 = new Juvenal("Juvenal", log);
//            Jogador jogador2 = new JurandirOJogador("", log);
//            Jogador jogador3 = new Juvenal("Juvenal", log);
//            Jogador jogador4 = new JurandirOJogador("", log);

//            log.logar("Juvenal X Jurandir", TipoLog.logTeste);
//            for (int x = 0; x < 1000; x++)

//            {

//                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
//                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });




//                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);


//                mesaDeTruco.Jogar();




//                if (equipe1.PontosEquipe >= 15)
//                {
//                    juvenal++;
//                }
//                else if (equipe2.PontosEquipe >= 15)
//                {
//                    Jurandir++;
//                }
//                else
//                {
//                    empate++;
//                }

//            }
//            log.logar(juvenal + "        " + Jurandir, TipoLog.logTeste);
//            log.logar("Juvenal ganhou {0}% das vezes \n\n", ((double)juvenal / 1000D) * 100D, TipoLog.logTeste);
//            log.logar("        \n   ", TipoLog.logTeste);
//            log.logar("A equipe 1 ganhou {0} vezes, e a equipe 2 ganhour {1}, ficou {2}", juvenal, Jurandir, empate, TipoLog.logTeste);

//        }

//        public void testarAlfa()
//        {

//            int juvenal = 0, alfa = 0, empate = 0;


//            Jogador jogador1 = new Juvenal("Juvenal", log);
//            Jogador jogador2 = new JogadorEquipeAlfa("Jogador Alfa", log);
//            Jogador jogador3 = new Juvenal("Juvenal", log);
//            Jogador jogador4 = new JogadorEquipeAlfa("Jogador Alfa", log);

//            log.logar("Juvenal X EquipeAlfa", TipoLog.logTeste);
//            for (int x = 0; x < 1000; x++)

//            {

//                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
//                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });




//                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);


//                mesaDeTruco.Jogar();




//                if (equipe1.PontosEquipe >= 15)
//                {
//                    juvenal++;
//                }
//                else if (equipe2.PontosEquipe >= 15)
//                {
//                    alfa++;
//                }
//                else
//                {
//                    empate++;
//                }

//            }
//            log.logar(juvenal + "       " + alfa, TipoLog.logTeste);
//            log.logar("Juvenal ganhou {0}% das vezes \n\n ", ((double)juvenal / 1000D) * 100D, TipoLog.logTeste);
//            log.logar("      \n     ", TipoLog.logTeste);

//            log.logar("A equipe 1 ganhou {0} vezes, e a equipe 2 ganhour {1}, ficou {2}", juvenal, alfa, empate, TipoLog.logTeste);

//        }
        



//    }
//}
