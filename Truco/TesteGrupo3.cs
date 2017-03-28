using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CardGame
{
    class TesteGrupo3
    {
        public StreamWriter n1;

        public TesteGrupo3()
        {
            n1 = new StreamWriter("Teste.txt");

        }


        public void testarIlusionista()
        {



            int juvenal = 0, ilusionista = 0, empate = 0;


            Jogador jogador1 = new Juvenal("Juvenal");
            Jogador jogador2 = new IlusionistaDaMesa("Ilusionista");
            Jogador jogador3 = new Juvenal("Juvenal");
            Jogador jogador4 = new IlusionistaDaMesa("Ilusionista");

            n1.WriteLine("okokJuvenal X Ilusionista");

            for (int x = 0; x < 1000; x++)

            {

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });




                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });


                mesaDeTruco.Jogar();




                if (equipe1.PontosEquipe >= 15)
                {
                    juvenal++;
                }
                else if (equipe2.PontosEquipe >= 15)
                {
                    ilusionista++;
                }
                else
                {
                    empate++;
                }

            }
            n1.WriteLine(juvenal + "            " + ilusionista);
            n1.WriteLine("Juvenal ganhou {0}% das vezes \n\n", ((double)juvenal / 1000D) * 100D);
            n1.WriteLine("          \n ");
            Console.WriteLine("A equipe 1 ganhou {0} vezes, e a equipe 2 ganhour {1}, ficou {2}", juvenal, ilusionista, empate);

        }

        public void testarJurandir()
        {



            int juvenal = 0, Jurandir = 0, empate = 0;


            Jogador jogador1 = new Juvenal("Juvenal");
            Jogador jogador2 = new JurandirOJogador();
            Jogador jogador3 = new Juvenal("Juvenal");
            Jogador jogador4 = new JurandirOJogador();

            n1.WriteLine("Juvenal X Jurandir");
            for (int x = 0; x < 1000; x++)

            {

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });




                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });


                mesaDeTruco.Jogar();




                if (equipe1.PontosEquipe >= 15)
                {
                    juvenal++;
                }
                else if (equipe2.PontosEquipe >= 15)
                {
                    Jurandir++;
                }
                else
                {
                    empate++;
                }

            }
            n1.WriteLine(juvenal + "        " + Jurandir);
            n1.WriteLine("Juvenal ganhou {0}% das vezes \n\n", ((double)juvenal / 1000D) * 100D);
            n1.WriteLine("        \n   ");
            Console.WriteLine("A equipe 1 ganhou {0} vezes, e a equipe 2 ganhour {1}, ficou {2}", juvenal, Jurandir, empate);

        }

        public void testarAlfa()
        {

            int juvenal = 0, alfa = 0, empate = 0;


            Jogador jogador1 = new Juvenal("Juvenal");
            Jogador jogador2 = new JogadorEquipeAlfa("Jogador Alfa");
            Jogador jogador3 = new Juvenal("Juvenal");
            Jogador jogador4 = new JogadorEquipeAlfa("Jogador Alfa");

            n1.WriteLine("Juvenal X EquipeAlfa");
            for (int x = 0; x < 1000; x++)

            {

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });




                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });


                mesaDeTruco.Jogar();




                if (equipe1.PontosEquipe >= 15)
                {
                    juvenal++;
                }
                else if (equipe2.PontosEquipe >= 15)
                {
                    alfa++;
                }
                else
                {
                    empate++;
                }

            }
            n1.WriteLine(juvenal + "       " + alfa);
            n1.WriteLine("Juvenal ganhou {0}% das vezes \n\n ", ((double)juvenal / 1000D) * 100D);
            n1.WriteLine("      \n     ");

            Console.WriteLine("A equipe 1 ganhou {0} vezes, e a equipe 2 ganhour {1}, ficou {2}", juvenal, alfa, empate);

        }

        public void fechaArquivo()
        {

            n1.Close();

        }



    }
}
