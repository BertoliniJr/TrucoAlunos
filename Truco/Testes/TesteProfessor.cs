using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using System.IO;

namespace Truco.Testes
{
    static class TesteProfessor
    {
        static public void testeProfessor()
        {
            changeOutput(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SaidaTruco.txt");

            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\testeProfessor.txt";

            Equipe eqp1 = new Equipe(new List<Jogador>() { new JogadorProfessor("H1"), new JogadorProfessor("H2") });

            // Professor contra jogador
            Equipe eqp2 = new Equipe(new List<Jogador>() { new Jogador("J1"), new Jogador("J2") });
            teste(eqp1, eqp2, caminho, 1000);

            // Professor conta equipe Alffa
            Equipe eqp3 = new Equipe(new List<Jogador>() { new JogadorEquipeAlfa("A1"), new JogadorEquipeAlfa("A2") });
            teste(eqp1, eqp3, caminho, 1000);


            // Professor conta equipe Juvenal
            Equipe eqp4 = new Equipe(new List<Jogador>() { new Juvenal("Juvena1"), new Juvenal("Juvena2") });
            teste(eqp1, eqp4, caminho, 1000);


            // Professor conta equipe Jurandir
            Equipe eqp5 = new Equipe(new List<Jogador>() { new JurandirOJogador("Jurandir1"), new JurandirOJogador("Jurandir2") });
            teste(eqp1, eqp5, caminho, 1000);


            // Professor conta equipe Ilusionista
            Equipe eqp6 = new Equipe(new List<Jogador>() { new IlusionistaDaMesa("Ilu1"), new IlusionistaDaMesa("Ilu2") });
            teste(eqp1, eqp6, caminho, 1000);
        }

        static private void teste(Equipe equipe1, Equipe equipe2, string arquivo, int rodadas)
        {
            int v1 = 0;
            int v2 = 0;

            Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
            
            for (int i = 0; i < rodadas; i++)
            {
                mesaDeTruco.Jogar(); if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                    v1++;
                else
                    v2++;
            }

            FileStream fs = new FileStream(arquivo, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine($"{equipe1} vs {equipe2}");
            sw.WriteLine();
            sw.WriteLine($"A {equipe1} ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine($"A {equipe2} ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.WriteLine();
            sw.Close();

        }

        static public void changeOutput(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create);

            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);
        }
    }
}
