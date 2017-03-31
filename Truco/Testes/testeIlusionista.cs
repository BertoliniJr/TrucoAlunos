using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using System.IO;
using Truco.Auxiliares;

namespace Truco
{
    public class testeIlusionista
    {
        private Log log;
        public testeIlusionista(Log logar)
        {
            log = logar;
        }
        public void testePC()
        {
            
            int v1 = 0;
            int v2 = 0;


            for (int i = 0; i < 1000; i++)
            {

                Jogador jogador1 = new Jogador("Jogador 1", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new Jogador("Jogador 3", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe PC vs Equipe Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe PC ganhou {0}, {1}% ", v1 , (double)(v1)/(double)((v1+v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista ganhou {0}, {1}% ", v2 , (double)(v2)/(double)((v1+v2))* 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);

        }

        public void TesteJura()
        {
            
            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JurandirOJogador("", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new JurandirOJogador("", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }
            
            log.logar("Equipe Jura vs Equipe Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Jura ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteJuvena()
        {
            


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Juvena 1", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new Juvenal("Juvena 3", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe Juvena vs Equipe Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Juvena ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }
        
        public void TesteAlfa()
        {
           


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Juvena 1", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new JogadorEquipeAlfa("Juvena 3", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);
                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }
            
            log.logar("Equipe Alfa vs Equipe Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Alfa ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteIlusionistaEJurandi()
        {
            


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Alfa 1", log);
                Jogador jogador2 = new JurandirOJogador("", log);
                Jogador jogador3 = new Juvenal("Juvena 3", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe Alfa e Juvenal vs Equipe Ilusionista e Jurandi", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Alfa e Juvenal ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista e Jurandi ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteIlusionistaEJuvenal()
        {
            

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Alfa 1", log);
                Jogador jogador2 = new Juvenal("Juvena 2", log);
                Jogador jogador3 = new JurandirOJogador("", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }
            
            log.logar("Equipe Alfa e Jurandi vs Equipe Ilusionista e Juvenal", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Alfa e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista e Juvenal ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteIlusionistaEAlfa()
        {
            

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Juvena 1", log);
                Jogador jogador2 = new Juvenal("Alfa 2", log);
                Jogador jogador3 = new JurandirOJogador("", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe Juvenal e Jurandi vs Equipe Ilusionista e Alfa", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Juvenal e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista e Alfa ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteIlusionistaEIlusionista()
        {
          

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new IlusionistaDaMesa("Ilusionista 1", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new IlusionistaDaMesa("Ilusionista 3", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe Ilusionista e Ilusionista vs Equipe Ilusionista e Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Ilusionista 1 ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista 2 ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteIlusionistaEJuJu()
        {


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Juvena 1", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new JurandirOJogador("", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe Juvenal e Jurandi vs Equipe Ilusionista e Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Juvenal e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista  ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteIlusionistaEJuraAlfa()
        {

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JurandirOJogador("", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new JogadorEquipeAlfa("Alfa 3", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe Alfa e Jurandi vs Equipe Ilusionista e Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Alfa e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }

        public void TesteIlusionistaEAlfaeJuve()
        {

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Alfa 1", log);
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2", log);
                Jogador jogador3 = new Juvenal("Juvenal 3", log);
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4", log);

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 }, log);


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            log.logar("Equipe Juvenal e Alfa vs Equipe Ilusionista e Ilusionista", TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
            log.logar("A equipe Juvenal e Alfa ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("A equipe Ilusionista 2 ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D, TipoLog.logTeste);
            log.logar("", TipoLog.logTeste);
        }
    }


}
