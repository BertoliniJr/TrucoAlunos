using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using System.IO;
using Truco.Auxiliares;

namespace Truco.Testes
{
    static class TesteProfessor
    {
        static public void testeProfessor(Log log)
        {
            changeOutput(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SaidaTruco.txt");

            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\testeProfessor.txt";

            Equipe eqp1 = new Equipe(new List<Jogador>() { new JogadorProfessor("H1", log), new JogadorProfessor("H2", log) });

            // Professor contra jogador
            Equipe eqp2 = new Equipe(new List<Jogador>() { new Jogador("J1", log), new Jogador("J2", log) });
            teste(eqp1, eqp2, caminho, 1000, log);

            // Professor conta equipe Alffa
            Equipe eqp3 = new Equipe(new List<Jogador>() { new JogadorEquipeAlfa("A1", log), new JogadorEquipeAlfa("A2", log) });
            teste(eqp1, eqp3, caminho, 1000, log);


            // Professor conta equipe Juvenal
            Equipe eqp4 = new Equipe(new List<Jogador>() { new Juvenal("Juvena1", log), new Juvenal("Juvena2", log) });
            teste(eqp1, eqp4, caminho, 1000, log);


            // Professor conta equipe Jurandir
            Equipe eqp5 = new Equipe(new List<Jogador>() { new JurandirOJogador("Jurandir1", log), new JurandirOJogador("Jurandir2", log) });
            teste(eqp1, eqp5, caminho, 1000, log);


            // Professor conta equipe Ilusionista
            Equipe eqp6 = new Equipe(new List<Jogador>() { new IlusionistaDaMesa("Ilu1", log), new IlusionistaDaMesa("Ilu2", log) });
            teste(eqp1, eqp6, caminho, 1000, log);
        }

        static private void teste(Equipe equipe1, Equipe equipe2, string arquivo, int rodadas, Log log)
        {
            int v1 = 0;
            int v2 = 0;

            Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
            
            for (int i = 0; i < rodadas; i++)
            {
                mesaDeTruco.Jogar(); if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                    v1++;
                else
                    v2++;
            }
            

            log.logar($"{equipe1} vs {equipe2}", TipoLog.logTeste, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar($"A {equipe1} ganhou {v1}, {(double)(v1) / (double)((v1 + v2)) * 100D}% ", TipoLog.logTeste);
            log.logar($"A {equipe2} ganhou {v2}, {(double)(v2) / (double)((v1 + v2)) * 100D}% ", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);

        }

        static public void changeOutput(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create);

            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);
        }
    }
}
